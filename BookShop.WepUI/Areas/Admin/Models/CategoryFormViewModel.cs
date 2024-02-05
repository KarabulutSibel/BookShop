using System.ComponentModel.DataAnnotations;

namespace BookShop.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Kategori adını girmek zorunludur.")]
        public string Name { get; set; }
    }
  
}
