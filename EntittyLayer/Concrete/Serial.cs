using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Serial
    {
        [Key]
        public int SerialID { get; set; }

        [StringLength(10)]
        public string SerialName { get; set; }

        public int? ModelID { get; set; }
        public virtual Model Models { get; set; }
        public ICollection<Advert> Adverts { get; set; }


    }
}
