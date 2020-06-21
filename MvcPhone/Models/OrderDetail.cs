using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class OrderDetail
    {
        [Key]
        public int idCTHD { get; set; }
        public int idHD { get; set; }
        public int idSP { get; set; }
        public int soluong { get; set; }
        public float dongia { get; set; }
        public float thanhtien { get; set; }
        public float khuyenmai { get; set; }
        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}
