using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using api.Entity;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if (await context.Users.AnyAsync()) return;

            // no users in DB, parse seed data
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();

                // the dummy users will all have the same password
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("password123"));
                user.PasswordSalt = hmac.Key;

                // only tracking the entities
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
