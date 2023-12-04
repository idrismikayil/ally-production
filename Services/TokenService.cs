using ally.DAL;
using ally.Models;
using Microsoft.EntityFrameworkCore;

namespace ally.Services
{
    public class TokenSerivce(AppDbContext context) : ITokenService
    {
        public async Task AddTokenToDatabase(string token)
        {
            var SessionToken = new SessionToken()
            {
                Token = token,
                ExpirationDate = DateTime.UtcNow.AddDays(14),
            };
            await context.Tokens.AddAsync(SessionToken);
            await context.SaveChangesAsync();
        }

        public async Task RemoveTokenFromDatabase(string token)
        {
            await context.Tokens.FirstOrDefaultAsync(t => t.Token.Equals(token));
        }
    }
}
