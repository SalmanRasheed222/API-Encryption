namespace API_Encryption.Models
{
    public class insertstudent
    {
        public string insertname { get; set; }
        public string insertclass { get; set; }

    }

    public class updatestudent {
        public int updateid { get; set; }
        public string updatename { get; set; }
        public string updateclass { get; set; }

    }

    public class deletestudent
    {
        public int deleteid { get; set;}
    }


}
