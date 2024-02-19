
using EntitiesLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EfCore.Config
{
    public class MovieConfig : IEntityTypeConfiguration<Movies>
    {
        public void Configure(EntityTypeBuilder<Movies> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Moviename);
            builder.Property(x => x.MovieDetail);
            builder.Property(x => x.ImageUrl);
            builder.Property(x => x.Director);
            builder.Property(x => x.Cast);
            builder.Property(x => x.ImdbRate);

            builder.HasData(
                new Movies() { Id=1,Moviename = "Titanik", MovieDetail = "Dünyanın hatırlamak istemediği türden felaketlerden olan 'Titanik faciası', dev prodüksiyonların yönetmeni James Cameron tarafından çekilen görkemli bir film.\r\nTeknolojinin son sürat ilerlediği bir dönemde, insanlar üstesinden gelemeyecekleri hiç bir sorun olamayacağına inanmaya başlamışlardır. 'Titanic' adlı dev transatlantik ise, insanlığın doğaya karşı gövde gösterisi gibidir", Cast = "Leonardo DiCaprio, Kate Winslet, Billy Zane", Director = "James Cameron", ImageUrl = "/images/titanik.jpg", ImdbRate = 8,GenreId=1,Duration= "3s 14d",Year=1997 }
            );
        }
    }
}
