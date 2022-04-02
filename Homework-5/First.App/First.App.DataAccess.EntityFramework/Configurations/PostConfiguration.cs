using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace First.App.DataAccess.EntityFramework.Configurations
{
    internal class PostConfiguration : IEntityTypeConfiguration<Posts>//benim veri tabanındaki oluşturacağım tablonun ilgili propertyleri sağlayan configuration classıdır.
    {
        public void Configure(EntityTypeBuilder<Posts> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.title).IsRequired();
            builder.Property(x => x.username).IsRequired();
            builder.Property(x => x.Body).IsRequired();
        }
    }
}
