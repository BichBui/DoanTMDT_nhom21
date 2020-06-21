using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class Worker
    {
        [Key]
        public int STT { get; set; }
        public string idNV { get; set; }
        public string hoten { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
        [DataType(DataType.Date)]
        public DateTime ngaysinh { get; set; }
        public string gioitinh { get; set; }
        public int luong { get; set; }
        public string pass { get; set; }
        public string trangthai { get; set; }
        public string phanquyen { get; set; }
        public virtual Category Categorys { get; set; }
        public virtual Product Products { get; set; }
        public virtual Order Orders { get; set; }
        public virtual OrderDetail OrderDetails { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
