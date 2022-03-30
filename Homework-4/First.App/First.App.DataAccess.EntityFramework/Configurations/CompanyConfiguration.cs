using First.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace First.App.DataAccess.EntityFramework.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>// <> içerisne tablo adı yazıyorsun.
    {
        public void Configure(EntityTypeBuilder<Company> builder)// companyi implent etti
        {
            builder.ToTable("Companies");// nokta diyip haskey şeklinde de devam edebilirdin.
            builder.HasKey(x=> x.Id);//primary keyini belirtmiş oluyorsun.
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
