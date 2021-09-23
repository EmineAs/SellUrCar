using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Gear
    {
        [Key]
        public int GearID { get; set; }

        [StringLength(20)]
        public string GearType { get; set; }

        public ICollection<Advert> Adverts { get; set; }

    }
}
