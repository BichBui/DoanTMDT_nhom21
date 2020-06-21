using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class Product
    {
        [Key]
        public int idSP { get; set; }
        public int idLSP { get; set; }
        public string tenSP { get; set; }
        public string mota { get; set; }
        public float gia { get; set; }
        public string hinhanh { get; set; }
        public virtual Category Categorys { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
