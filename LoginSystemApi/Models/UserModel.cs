namespace LoginSystemApi.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? Cpf { get; set; }

        public bool IsActive {  get; set;
        public ICollection<UserRoleModel> UserRoles{ get; set; }

        public UserModel() {
            this.UserRoles = new List<UserRoleModel>();
            this.IsActive = true;
        }
    }
}
