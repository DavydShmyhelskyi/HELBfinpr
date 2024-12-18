using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class UserRepository : BaseInterface<User>
    {
        private readonly LnContext _context;
        private LnContext lnContext;
        private LnContext lnContext1;

        public UserRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(User entity)
        {
            _context.Users.Add(entity);
        }

        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        public User Get(int id)
        {
            return _context.Users.Find(id);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

        public void Delete(int id)
        {
            var user = Get(id);
            if (user != null)
                _context.Users.Remove(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
