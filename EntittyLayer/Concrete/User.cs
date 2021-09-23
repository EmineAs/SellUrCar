using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string UserSurName { get; set; }

        [StringLength(250)]
        public string UserImage { get; set; }

        [StringLength(20)]
        public string UserMail { get; set; }

        [StringLength(20)]
        public string UserPhoneNumber { get; set; }

        [StringLength(10)]
        public string UserPassWord { get; set; }

        public bool UserStatus { get; set; }

        public ICollection<Advert> Adverts { get; set; }
    }
}
