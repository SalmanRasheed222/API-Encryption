using API_Encryption.API_Security;
using API_Encryption.DB_Classes;
using API_Encryption.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API_Encryption.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class studentController : ControllerBase
    {
        DBManager dBManager;

        IConfiguration configuration1;
        public  studentController(DBManager dBManager ,IConfiguration configuration)
        {
            this.dBManager = dBManager;
            this.configuration1= configuration;
        }


        [HttpGet]
        [Route("showstudent")]
        public List<Student> showstudent()
        {
          return  dBManager.students.Where(row=>row.status==true).ToList();

        }

         [AllowAnonymous]
        [HttpPost]
        [Route("logintheuser")]
        public ResponseClass logintheuser(Loginclass logininfo)
        {
            ResponseClass responseClass = new ResponseClass();
            LoginUser loginUser = dBManager.LoginUsers.Where(row => row.UserName == logininfo.UserName && row.Password == logininfo.Password).FirstOrDefault();
            if (logininfo.UserName=="salman"&& logininfo.Password=="123" )
            {
                responseClass.Result = "Successfully Login";
                responseClass.ObjectData = GenerateJSONWebToken(logininfo);
                
            }
            else
            {
                responseClass.Result = "Invalid UserName /Password";
            }
            return responseClass;
        }

        private string GenerateJSONWebToken(Loginclass logininfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration1["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] { new Claim("UserName", logininfo.UserName), new Claim("Id", "2") };

            var token = new JwtSecurityToken(configuration1["Jwt:Issuer"],
              configuration1["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(480),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        [Route("addstudent")]
    public string addstudent(insertstudent insertstudent)
        {
             Student student=dBManager.students.Where(row=>row.sname==insertstudent.insertname).FirstOrDefault();
            if(student ==null)
            {
                Student s=new Student();
                s.sname = insertstudent.insertname;
                s.sclass = insertstudent.insertclass;
                s.status = true;
                s.Creation_Time = DateTime.Now;
                dBManager.Add(s);
                dBManager.SaveChanges();
                return "Inserted Successfully";
            }
            else
            {
                return "Student  Is Already Exist.";
            }

        }

        [HttpPut]
        [Route("updatestudents")]
        public string updatestudents(updatestudent updatestudent)
        {
            Student student = dBManager.students.Where(row => row.id == updatestudent.updateid).FirstOrDefault();
            if(student==null)
            {
                return "Invalid Id";
            }
            else
            {
                student.sname = updatestudent.updatename;
                student.sclass = updatestudent.updateclass;
                student.status = true;
                student.Updation_Time= DateTime.Now;
                dBManager.Update(student);
                dBManager.SaveChanges();
                return "Updated Successfully.";
            }

        }

        [HttpDelete]
        [Route("deletestudents")]
        public string deletestudents(deletestudent deletestudent)
        {
            Student student = dBManager.students.Where(row => row.id == deletestudent.deleteid).FirstOrDefault();
            if (student == null)
            {
                return "Invalid Id";
            }
            else
            {
                student.id = deletestudent.deleteid;
                student.status = false;
                student.Updation_Time = DateTime.Now;
                return "Deleted Successfully.";
            }

        }



    }
}
