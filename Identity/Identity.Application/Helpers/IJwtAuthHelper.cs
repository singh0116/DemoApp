namespace Identity.Application.Helpers
{
    public interface IJwtAuthHelper
    {
        string GenerateToken(string userId, string email, string role);
    }
}
