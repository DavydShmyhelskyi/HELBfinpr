using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class UserDictionaryStatusRepository : BaseInterface<UserDictionaryStatus>
    {
        private readonly LnContext _context;

        public UserDictionaryStatusRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(UserDictionaryStatus entity)
        {
            _context.UserDictionaryStatuses.Add(entity);
        }

        public IEnumerable<UserDictionaryStatus> Get()
        {
            return _context.UserDictionaryStatuses.ToList();
        }

        public UserDictionaryStatus Get(int id)
        {
            return _context.UserDictionaryStatuses.Find(id);
        }

        public void Update(UserDictionaryStatus entity)
        {
            _context.UserDictionaryStatuses.Update(entity);
        }

        public void Delete(int id)
        {
            var userDictionaryStatus = Get(id);
            if (userDictionaryStatus != null)
                _context.UserDictionaryStatuses.Remove(userDictionaryStatus);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
