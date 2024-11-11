using LoginSystemApi.Enums;

namespace LoginSystemApi.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public ERoles Role{ get; set; }

        public ICollection<User> Users { get; set; }
    }
}
