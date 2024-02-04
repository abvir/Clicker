using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.Configurations;

internal class UrlAddressConfiguration : IEntityTypeConfiguration<UrlAddress>
{
    public void Configure(EntityTypeBuilder<UrlAddress> builder)
    {
        builder.ToTable("urls");

        builder.HasKey(x => x.Id).HasName("pk_urls");

        builder.HasIndex(x => x.ShortUrl).IsUnique();
        builder.Property(x=>x.OriginalUrl).HasColumnName("original_url").IsRequired();
        
        builder.HasIndex(x=>x.ShortUrl).IsUnique();
        builder.Property(x=>x.ShortUrl).HasColumnName("short_url").IsRequired();
    }
}
