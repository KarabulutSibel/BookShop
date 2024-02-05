using BookShop.Business.Services;
using BookShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebUI.ViewComponents
{
	public class ProductsViewComponent : ViewComponent
	{
		private readonly IProductService _productService;

		public ProductsViewComponent(IProductService productService)
		{
			_productService = productService;
		}

		public IViewComponentResult Invoke(int? categoryId = null)
		{
			var productDtos = _productService.GetProductsByCategoryId(categoryId);

			var viewModel = productDtos.Select(x => new ProductViewModel
			{
				Id = x.Id,
				Name = x.Name,
				UnitPrice = x.UnitPrice,
				UnitsInStock = x.UnitsInStock,
				ImagePath = x.ImagePath,
				CategoryId = x.CategoryId,
				CategoryName = x.CategoryName,
			}).ToList();

			return View(viewModel);
		}
	}
}
