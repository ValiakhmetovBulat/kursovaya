using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace WindowsFormsApplication1
{
    public class UserContext : DbContext
        {
        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
        }
}
