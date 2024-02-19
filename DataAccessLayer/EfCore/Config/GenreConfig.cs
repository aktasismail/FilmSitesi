using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using EntitiesLayer;

namespace DataAccessLayer.EfCore.Config
{
    public class GenreConfig : IEntityTypeConfiguration<Genres>
    {
        public void Configure(EntityTypeBuilder<Genres> builder)
        {
            builder.HasKey(x => x.GenreId);
            builder.Property(x => x.MovieGenre);
         

            builder.HasData(
                new Genres() { GenreId=1,MovieGenre="Dram" }
            );
        }
    }
}
