﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryId { get; set; }

        // Relational Property
        public CategoryEntity Category { get; set; }
        public List<CommitEntity> Commits { get; set; }
    }
    public class ProductConfiguration : BaseConfiguration<ProductEntity> 
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.Description)
                .IsRequired(false);

            builder.Property(x => x.UnitPrice)
                .IsRequired(false);

            builder.Property(x => x.ImagePath)
                .IsRequired(false);

            base.Configure(builder);
        }
    }
}
