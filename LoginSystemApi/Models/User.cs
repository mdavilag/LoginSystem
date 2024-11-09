using LoginSystemApi.Enums;

namespace LoginSystemApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Cpf { get; set; }

        public IEnumerable<ERoles> Roles { get; set; }

        public User() { 
            Roles = new List<ERoles>();
        }
    }
}
