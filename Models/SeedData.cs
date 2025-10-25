using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
namespace dailyphongve.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            dailyphongveDbContext context =
            app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService < dailyphongveDbContext > ();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.ves.Any())
            {
                context.ves.AddRange(
                new ve
                {
                    Title = "oan hồn cô dâu",
                    time = "15h10",
                    Period="90 phút",
                    Genre = "kinh dị",
                    Price = 11m
                },
                new ve
                {
                    Title = "góa phụ đen",
                    time = "15h10",
                    Period = "120 phút",
                    Genre = "tình cảm",
                    Price = 13m
                },
                new ve
                {
                    Title = "đại uý marvel",
                    time = "17h40",
                    Period = "120 phút",
                    Genre = "siêu anh hùng",
                    Price = 15m
                },
                new ve
                {
                    Title = "titanic",
                    time = "17h40",
                    Period = "90 phút",
                    Genre = "tình cảm",
                    Price = 11m
                },
                new ve
                {
                    Title = "chủng tộc bất tử",
                    time = "19h",
                    Period = "90 phút",
                    Genre = "siêu anh hùng",
                    Price = 11m
                }
                ); context.SaveChanges();
            }
        }
    }
}