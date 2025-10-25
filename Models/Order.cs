using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
namespace dailyphongve.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [Required(ErrorMessage = "Nhập tên của bạn")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Nhập địa chỉ")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        [Required(ErrorMessage = "Nhập tên Đường ")] 
        public string City { get; set; }
        [Required(ErrorMessage = "Nhập tên thành phố ")]
        public string State { get; set; }
        public string Zip { get; set; }
        [Required(ErrorMessage = "Nhập tên quốc gia")]
        public string Country { get; set; }
        [BindNever]
        public bool Shipped { get; set; }
    }
}