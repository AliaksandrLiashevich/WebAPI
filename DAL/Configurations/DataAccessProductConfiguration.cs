using DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace DAL.Configurations
{
    public class DataAccessProductConfiguration : IEntityTypeConfiguration<DataAccessProduct>
    {
        public void Configure(EntityTypeBuilder<DataAccessProduct> builder)
        {
            builder.ToTable("tbl_products").HasKey(category => category.Id);
            builder.Property(product => product.Id).HasColumnName("cln_id");
            builder.Property(product => product.CategoryId).HasColumnName("cln_category_id");
            builder.Property(product => product.Name).HasColumnName("cln_name");
            builder.Property(product => product.Price).HasColumnName("cln_price");
            builder.Property(product => product.Quantity).HasColumnName("cln_quantity");
        }
    }
}
