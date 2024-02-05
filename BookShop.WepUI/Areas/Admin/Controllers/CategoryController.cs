using BookShop.Business.Dtos;
using BookShop.Business.Services;
using BookShop.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		public IActionResult List()
		{
			var categoryListDto = _categoryService.GetCategories();

			var viewModel = categoryListDto.Select(x => new CategoryListViewModel 
			{
				Id = x.Id,
				Name = x.Name,
			}).ToList();

			return View(viewModel);
		}

		public IActionResult New()
		{
			return View("Form", new CategoryFormViewModel());
				
		}

		public IActionResult Update(int id) 
		{
			var categoryDto = _categoryService.GetCategory(id);

			var viewModel = new CategoryFormViewModel
			{
				Id = categoryDto.Id,
				Name = categoryDto.Name
			};

			return View("Form", viewModel);
		}
		[HttpPost]
		public IActionResult Save(CategoryFormViewModel formData)
		{
			if (!ModelState.IsValid)
			{
				return View("Form", formData);
			}

			if (formData.Id == 0)
			{
				var addCategoryDto = new AddCategoryDto
				{
					Name = formData.Name,
				};

				var result = _categoryService.AddCategory(addCategoryDto);

				if (result)
				{
					return RedirectToAction("List");
				}
				else
				{
					ViewBag.ErrorMessage = "Bu isimde bir kategori zaten mevcut.";
					return View("Form", formData);
				}
			}

			else 
			{
				var updateCategoryDto = new UpdateCategoryDto
				{
					Id = formData.Id,
					Name = formData.Name,
				};

				_categoryService.UpdateCategory(updateCategoryDto);

				return RedirectToAction("List");
			}
		}

		public IActionResult Delete(int id) 
		{
			_categoryService.DeleteCategory(id);

			return RedirectToAction("List");
		}
	}
}
