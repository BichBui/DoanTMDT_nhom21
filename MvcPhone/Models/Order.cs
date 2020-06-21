using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class Order
    {
        [Key]
        public int idHD { get; set; }
        public int idUser { get; set; }
        public string hoten_user { get; set; }
        public string gmail_user { get; set; }
        public string phone_user { get; set; }
        public string diachi_user { get; set; }
        public float tongtien { get; set; }
        public string payment { get; set; }
        [DataType(DataType.Date)]
        public DateTime ngaytao { get; set; }
        public int trangthai { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
