using DAL.Interfaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class DataAccessCategoryConfiguration : IEntityTypeConfiguration<DataAccessCategory>
    {
        public void Configure(EntityTypeBuilder<DataAccessCategory> builder)
        {
            builder.ToTable("tbl_categories").HasKey(category => category.Id);
            builder.Property(category => category.Id).HasColumnName("cln_id");
            builder.Property(category => category.Name).HasColumnName("cln_name");
            builder.Property(category => category.Code).HasColumnName("cln_code");

            builder.HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryId);
        }
    }
}
