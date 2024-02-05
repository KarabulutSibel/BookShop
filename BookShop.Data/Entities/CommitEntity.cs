using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Entities
{
	public class CommitEntity : BaseEntity
	{
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string? Content { get; set; }

        //Relational Property
        public UserEntity User { get; set; }
        public ProductEntity Product { get; set; }
    }
}
