using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Advert> Adverts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Message> Messages { get; set; }

    }
}
