using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class UserStatusRepository : BaseInterface<UserStatus>
    {
        private readonly LnContext _context;

        public UserStatusRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(UserStatus entity)
        {
            _context.UserStatuses.Add(entity);
        }

        public IEnumerable<UserStatus> Get()
        {
            return _context.UserStatuses.ToList();
        }

        public UserStatus Get(int id)
        {
            return _context.UserStatuses.Find(id);
        }

        public void Update(UserStatus entity)
        {
            _context.UserStatuses.Update(entity);
        }

        public void Delete(int id)
        {
            var userStatus = Get(id);
            if (userStatus != null)
                _context.UserStatuses.Remove(userStatus);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
