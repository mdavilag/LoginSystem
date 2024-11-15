namespace LoginSystemApi.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public ICollection<UserRoleModel> UserRoles{ get; set; }

        public RoleModel()
        {
            this.UserRoles = new List<UserRoleModel>();
        }
    }
}
