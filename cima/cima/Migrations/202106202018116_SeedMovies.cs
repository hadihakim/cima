namespace cima.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMovies : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[Movies] ON
INSERT INTO [dbo].[Movies] ([movieid], [movieName], [movieYear], [movieSeason], [starring], [creator], [MovieGenre], [releaseDate], [userName]) VALUES (7, N'boss', 2021, 1, N'admin', N'admin', 0, N'2021-06-06 20:15:00', N'admin@gmail.com')
INSERT INTO [dbo].[Movies] ([movieid], [movieName], [movieYear], [movieSeason], [starring], [creator], [MovieGenre], [releaseDate], [userName]) VALUES (8, N'nada', 2021, 1, N'none', N'none', 0, N'2021-06-06 20:15:00', N'cinema3@gmail.com')
INSERT INTO [dbo].[Movies] ([movieid], [movieName], [movieYear], [movieSeason], [starring], [creator], [MovieGenre], [releaseDate], [userName]) VALUES (9, N'happy', 2021, 1, N'any', N'any', 3, N'2021-06-20 22:49:00', N'testrole2@gmail.com')
SET IDENTITY_INSERT [dbo].[Movies] OFF

SET IDENTITY_INSERT [dbo].[Showtimes] ON
INSERT INTO [dbo].[Showtimes] ([showtimeId], [movieId], [day], [time1], [time2], [time3], [time4]) VALUES (2, 7, 1, N'2021-06-05 21:00:00', N'2021-06-05 20:00:00', N'2021-06-05 18:00:00', N'2021-06-05 19:30:00')
INSERT INTO [dbo].[Showtimes] ([showtimeId], [movieId], [day], [time1], [time2], [time3], [time4]) VALUES (3, 8, 1, N'2021-06-05 21:00:00', N'2021-06-05 20:00:00', N'2021-06-05 17:00:00', N'2021-06-05 19:30:00')
INSERT INTO [dbo].[Showtimes] ([showtimeId], [movieId], [day], [time1], [time2], [time3], [time4]) VALUES (4, 9, 2, N'2021-06-05 17:00:00', N'2021-06-05 22:00:00', N'2021-06-05 20:00:00', N'2021-06-05 17:15:00')
SET IDENTITY_INSERT [dbo].[Showtimes] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
