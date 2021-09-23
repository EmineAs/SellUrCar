using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Brand
    {
        [Key]
        public int BrandID { get; set; }

        [StringLength(20)]
        public string BrandName { get; set; }

        public ICollection<Model> Models { get; set; }
        public ICollection<Advert> Adverts { get; set; }
    }
}
