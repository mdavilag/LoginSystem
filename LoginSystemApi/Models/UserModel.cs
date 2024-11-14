namespace LoginSystemApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Cpf { get; set; }
        public ICollection<RoleModel> Roles { get; set; }

        public UserModel() {
            this.Roles = new List<RoleModel>();
        }
    }
}
