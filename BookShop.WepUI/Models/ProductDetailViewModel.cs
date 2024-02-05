using BookShop.Business.Dtos;
using BookShop.Data.Entities;

namespace BookShop.WebUI.Models
{
	public class ProductDetailViewModel
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImagePath { get; set; }
        public List<ListCommitDto> Commits { get; set; }
    }
}
