using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Dtos
{
	public class ProductDetailDto
	{
        public int Id { get; set; }
        public string Name { get; set; }
		public string Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public string ImagePath { get; set; }
    }
}
