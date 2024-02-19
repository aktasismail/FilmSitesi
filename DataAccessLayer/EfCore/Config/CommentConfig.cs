//using EntitiesLayer;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace DataAccessLayer.EfCore.Config
//{
//    public class CommentConfig : IEntityTypeConfiguration<Comments>
//    {
//        public void Configure(EntityTypeBuilder<Comments> builder)
//        {
//            builder.HasKey(x => x.CommentId);
//            builder.Property(x => x.FullName);
//            builder.Property(x => x.CommentText);


//            builder.HasData(
//                new Comments() { CommentId = 1, CommentText = "sgsgr", FullName = "ekgfmwegk", MovieId = 1 }
//            );
//        }
//    }
//}
