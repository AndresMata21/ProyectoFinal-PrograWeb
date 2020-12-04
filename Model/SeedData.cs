using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace proyectoFinal.Model {
    public class SeedData {
        public static void Initialize(IServiceProvider serviceProvider) {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>())) { //
                
                //Create database
                context.Database.EnsureCreated();
                
                if (context.Musics.Any()) {
                    //DB has been seeded already
                    Console.WriteLine("DB is already populated");
                    return;
                }
                
                var song1 = new Music() {
                    Name = "Another One Bites the Dust",
                    Album = "The Game",
                    Artist = "Queen",
                    Genre = "Rock",
                    Year = "1980"
                };
                
                var song2 = new Music() {
                    Name = "Affection",
                    Album = "Affection",
                    Artist = "Cigarettes After Sex",
                    Genre = "Dream Pop",
                    Year = "2015"
                };
                
                var song3 = new Music() {
                    Name = "ukulele and chill",
                    Album = "N/A",
                    Artist = "Cody G.",
                    Genre = "New Age",
                    Year = "2017"
                };

                context.Musics.Add(song1);
                context.Musics.Add(song2);
                context.Musics.Add(song3);
                context.SaveChanges();

            }
        }
    }
}