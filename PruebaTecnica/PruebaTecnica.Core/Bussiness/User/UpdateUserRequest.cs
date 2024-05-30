namespace PruebaTecnica.Core.Bussiness.User
{
    public class UpdateUserRequest
    {
        public string Name { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string? Website { get; set; }
    }
}
