using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Dtos
{
	public class AddCommitDto
	{
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }

    }
}
