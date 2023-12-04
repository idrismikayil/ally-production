namespace ally.Services
{
    public interface ITokenService
    {
        public Task AddTokenToDatabase(string token);
        public Task RemoveTokenFromDatabase(string token);

    }
}
