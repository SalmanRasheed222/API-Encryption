using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Encryption.DB_Classes
{
    public class LoginUser:Parentclass
    {
        [Column(TypeName="varchar(150)")]
        [Required]
        public string  UserName { get; set; }

        [Column(TypeName="varchar(150)")]
        [Required]
        public string Password { get; set; }

    }

}
