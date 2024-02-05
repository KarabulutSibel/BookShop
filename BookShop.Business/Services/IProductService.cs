using BookShop.Business.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Services
{
	public interface IProductService
	{
		List<ListProductDto> GetProducts();
		List<ListProductDto> GetProductsByCategoryId(int? categoryId);
		UpdateProductDto GetProductById(int id);
		void AddProduct(AddProductDto addProductDto);
		void UpdateProduct(UpdateProductDto updateProductDto);
		void DeleteProduct(int id);
		ProductDetailDto GetProductDetailById(int id);
	}
}
