using API_Encryption.API_Security;
using API_Encryption.DB_Classes;
using Microsoft.EntityFrameworkCore;

namespace API_Encryption
{
    public class DBManager:DbContext
    {
        public DBManager(DbContextOptions cn):base(cn)
        { }

        public DbSet<Student> students { get; set; }
        public DbSet<LoginUser> LoginUsers { get; set; }

    }
}
