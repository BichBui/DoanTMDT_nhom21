using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MvcPhone.Models
{
    public class Customer
    {
        [Key]
        public int idUser { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên đăng nhập.")]
        public string tendangnhap { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu.")]
        [StringLength(20, ErrorMessage = "Tối thiểu 6 kí tự, tối đa 20 kí tự.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string matkhau { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập lại mật khẩu.")]
        [DataType(DataType.Password)]
        [Compare("matkhau", ErrorMessage = "Mật khẩu không khớp.")]
        public string matkhaunhaplai { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập họ tên.")]
        public string hoten { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập gmail.")]
        [EmailAddress]
        public string gmail { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại.")]
        [StringLength(10, ErrorMessage = "Nhập sai số điện thoại", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        public string sdt { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        public string diachi { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
