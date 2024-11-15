namespace LoginSystemApi.Models
{
    public class UserRoleModel
    {
        public int UserId { get; set; }
        public UserModel User{ get; set; }
        public int RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
