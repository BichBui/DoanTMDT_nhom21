using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class Category
    {
        [Key]
        public int idLSP { get; set; }
        public string tenloai { get; set; }
        public string maloai { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
