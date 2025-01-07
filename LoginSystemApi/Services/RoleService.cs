using LoginSystemApi.Data;

namespace LoginSystemApi.Services
{
    public class RoleService
    {
        private readonly DataContext _context;

        public RoleService(DataContext context)
        {
            _context = context;
        }


    }
}
