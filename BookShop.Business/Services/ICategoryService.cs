using BookShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Services
{
	public interface ICategoryService
	{
		List<ListCategoryDto> GetCategories();
		bool AddCategory(AddCategoryDto addCategoryDto);
		UpdateCategoryDto GetCategory(int id);
		void UpdateCategory(UpdateCategoryDto updateCategoryDto);
		void DeleteCategory(int id);
	}
}
