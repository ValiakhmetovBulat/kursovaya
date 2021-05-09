using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace MyLib
{
    public partial class EntityModelContainer : DbContext
    {
        public EntityModelContainer() : base("userstore")
        {}
        public DbSet<User> Users { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Position> Positions { get; set; }
        
    }
}
