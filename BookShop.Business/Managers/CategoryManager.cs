using BookShop.Business.Dtos;
using BookShop.Business.Services;
using BookShop.Data.Entities;
using BookShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Managers
{
	public class CategoryManager : ICategoryService
	{
		private readonly IRepository<CategoryEntity> _categoryRepository;

		public CategoryManager(IRepository<CategoryEntity> categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public bool AddCategory(AddCategoryDto addCategoryDto)
		{
			var hasCategory = _categoryRepository.GetAll(x => x.Name.ToLower() == addCategoryDto.Name.ToLower()).ToList();

			if (hasCategory.Any())
			{
				return false;
			}

			var entity = new CategoryEntity()
			{
				Name = addCategoryDto.Name,
			};

			_categoryRepository.Add(entity);
			return true;
		}

        public void DeleteCategory(int id)
        {
            _categoryRepository.Delete(id);
        }

        public List<ListCategoryDto> GetCategories()
		{
			var categoryEnitites = _categoryRepository.GetAll().OrderBy(x => x.Name);

			var categoryListDto = categoryEnitites.Select(x => new ListCategoryDto
			{
				Id = x.Id,
				Name = x.Name,
			}).ToList();

			return categoryListDto;
		}

        public UpdateCategoryDto GetCategory(int id)
        {
            var entity = _categoryRepository.GetById(id);

			var updateCategoryDto = new UpdateCategoryDto
			{
				Id = entity.Id,
				Name = entity.Name,
			};

			return updateCategoryDto;
        }

        public void UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
			var entity = _categoryRepository.GetById(updateCategoryDto.Id);

			entity.Name = updateCategoryDto.Name;

			_categoryRepository.Update(entity);
        }
    }
}
