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

        public ICollection<RoleModel> Roles { get; set; }

        public User() {
            this.Roles = new List<RoleModel>();
            this.Roles.Add(new RoleModel());
        }
    }
}
