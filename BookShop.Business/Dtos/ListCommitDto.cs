﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Business.Dtos
{
	public class ListCommitDto
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int ProductId { get; set; }
        public string Content { get; set; }
        public bool IsDeleted { get; set; }
    }
}
