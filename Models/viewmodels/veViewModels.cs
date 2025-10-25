using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dailyphongve.Models.viewmodels
{
    public class veViewModels
    {
        [Key]
        public long veID { get; set; }
        [Display(Name = "tên vé")] public string Title { get; set; }
        [Display(Name = "thời gian")] public string time { get; set; }
        [Display(Name = "thời lượng")] public string Period { get; set; }
        [Display(Name = "loại vé")] public string Genre { get; set; }
        [Display(Name = "giá vé")] [Column(TypeName = "decimal(8, 2)")] public decimal Price { get; set; }
        public IFormFile Imageve { get; set; }
    }
}
