using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Fuel
    {
        [Key]
        public int FuelID { get; set; }

        [StringLength(10)]
        public string FuelType { get; set; }

        public ICollection<Advert> Adverts { get; set; }

    }
}
