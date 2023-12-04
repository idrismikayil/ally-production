using ally.Constants;
using ally.Services;

namespace ally.Utils
{
    public class SessionTokenMiddleware(ITokenService service) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string userToken = GetSessionTokenFromCookie(context);

            if (userToken.Equals(string.Empty))
            {
				await GenerateSessionToken(context);
			}
            await next(context);
        }

        private static string GetSessionTokenFromCookie(HttpContext context)
        {
            context.Request.Cookies.TryGetValue(TokenConstant.SessionToken, out string? token);
            return token ?? string.Empty;
        }

        private async Task GenerateSessionToken(HttpContext context)
        {
            string Token = Guid.NewGuid().ToString();
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                Expires = DateTime.UtcNow.AddDays(14)
            };
            context.Response.Cookies.Append(TokenConstant.SessionToken, Token, cookieOptions);
            await service.AddTokenToDatabase(Token);
        }

        private async Task DeleteSessionToken(HttpContext context)
        {
            context.Response.Cookies.Delete(TokenConstant.SessionToken);
            await service.RemoveTokenFromDatabase(TokenConstant.SessionToken);
        }
    }
}