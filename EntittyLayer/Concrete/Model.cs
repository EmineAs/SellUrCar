using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Model
    {
        [Key]
        public int ModelID { get; set; }

        [StringLength(50)]
        public string ModelName { get; set; }

        public int? SerialID { get; set; }
        public virtual Serial Serial { get; set; }

        public ICollection<Advert> Adverts { get; set; }










    }
}
