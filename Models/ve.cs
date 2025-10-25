using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dailyphongve.Models
{
    public class ve
    {
        [Key] 
        public long veID { get; set; }
        [Display(Name = "tên vé")] 
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter a title")]
        [Display(Name = "thời gian")] 
        public string time { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [Display(Name = "thời lượng")] 
        public string Period { get; set; }
        
        [Required]
        [Display(Name = "loại vé")] 
        public string Genre { get; set; }
        [Display(Name = "giá vé")][Column(TypeName = "decimal(8, 2)")] 
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Please specify a genre")]
        public string ProfilePicture { get; set; }
    }
}