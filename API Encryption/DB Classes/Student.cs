using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Encryption.DB_Classes
{
    public class Student:Parentclass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string sname { get; set; }
        public string sclass { get; set; }
        public bool status { get; set; }

    }
}
