using API_Encryption.DB_Classes;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Encryption.API_Security
{
    public class Loginclass:Parentclass
    {
       
        public string UserName { get; set; }
         
        public string  Password { get; set; }
    }
}
