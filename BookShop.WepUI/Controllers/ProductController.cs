using BookShop.Business.Dtos;
using BookShop.Business.Services;
using BookShop.WebUI.Extensions;
using BookShop.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICommitService _commitService;

		public ProductController(IProductService productService, ICommitService commitService)
		{
			_productService = productService;
			_commitService = commitService;
		}
		[HttpGet]
		public IActionResult Detail(int id)
		{
			var productDetailDto = _productService.GetProductDetailById(id);
			var listCommitDto = _commitService.GetCommits();

			var viewModel = new ProductDetailViewModel()
			{
				Id = productDetailDto.Id,
				Name = productDetailDto.Name,
				Description = productDetailDto.Description,
				UnitPrice = productDetailDto.UnitPrice,
				ImagePath = productDetailDto.ImagePath,
				Commits = listCommitDto,
			};

			var userId = HttpContext.User.GetUserId();
			ViewBag.UserId = userId;

			return View(viewModel);

		}
		[HttpGet]
		public IActionResult AddCommit(int productId)
		{
			ViewBag.ProductId = productId;
			return View();
		}
		[HttpPost]
		public IActionResult AddCommit(AddCommitViewModel formData, int productId)
		{
			var userId = HttpContext.User.GetUserId();

			var addCommitDto = new AddCommitDto
			{
				ProductId = productId,
				Content = formData.Content,
			};

			addCommitDto.UserId = userId;

			_commitService.AddCommit(addCommitDto);

			return RedirectToAction("Detail", "Product", new { id = productId });
		}

		public IActionResult EditCommit(int id)
		{
			var editCommitDto = _commitService.GetCommitById(id);

			var viewModel = new EditCommitViewModel
			{
				Id = editCommitDto.Id,
				Content = editCommitDto.Content,
				UserId = editCommitDto.UserId,
				ProductId = editCommitDto.ProductId,
			};

			return View(viewModel);
		}

		[HttpPost]
		public IActionResult EditCommit(EditCommitViewModel formData, int productId)
		{
			var editCommitDto = new EditCommitDto
			{
				Id = formData.Id,
				Content = formData.Content,
				UserId = formData.UserId,
				ProductId = formData.ProductId,
			};

			_commitService.EditCommit(editCommitDto);

			return RedirectToAction("Detail", "Product", new { id = productId });

		}

		public IActionResult DeleteCommit(int id, int productId)
		{
			_commitService.DeleteCommit(id);

			return RedirectToAction("Detail", "Product", new { id = productId });
		}
	}
}
