using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Advert
    {
        [Key]
        public int AdID { get; set; }

        public DateTime? AdvertDate { get; set; }

        [StringLength(50)]
        public String AdvertTitle { get; set; }

        public String AdvertDetail { get; set; }

        [StringLength(4)]
        public String ModelYear { get; set; }

        [StringLength(6)]
        public string CurrentMilage { get; set; }

        [StringLength(5)]
        public string EnginValume { get; set; }

        [StringLength(5)]
        public string EnginPower { get; set; }

        public decimal Price { get; set; }

        public int? BrandID { get; set; }
        public virtual Brand Brand { get; set; }

        public int? ModelID { get; set; }
        public virtual Model Model { get; set; }

        public int? SerialID { get; set; }
        public virtual Serial Serial { get; set; }

        public int? FuelID { get; set; }
        public virtual Fuel Fuel { get; set; }

        public int? GearID { get; set; }
        public virtual Gear Gear { get; set; }

        public int? ColorID { get; set; }
        public virtual Color Color { get; set; }

        public int? CityID { get; set; }
        public virtual City City { get; set; }

        public int? DistrictID { get; set; }
        public virtual District District { get; set; }

        public int? UserID { get; set; }
        public virtual User User { get; set; }

        public ICollection<ImageFile> ImageFiles { get; set; }
    }
}
