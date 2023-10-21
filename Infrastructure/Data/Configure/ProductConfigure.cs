using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configure;

public class ProductConfigure:IEntityTypeConfiguration<product>
{
    public void Configure(EntityTypeBuilder<product> builder)
    {

        builder.Property(x => x.name).IsRequired();
        builder.Property(x => x.price).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(x => x.description).IsRequired();
        builder.Property(x => x.pictureurl).IsRequired();
        builder.HasOne(x => x.producttype).WithMany().HasForeignKey(x => x.producttypeid);
        builder.HasOne(x => x.productbrand).WithMany().HasForeignKey(x => x.productbrandid);

    }
}