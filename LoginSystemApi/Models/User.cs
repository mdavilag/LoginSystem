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

        public List<ERoles> Roles { get; set; }

        public User() { 
            this.Roles = new List<ERoles>();
            this.Roles.Add(ERoles.User);
        }
    }
}
