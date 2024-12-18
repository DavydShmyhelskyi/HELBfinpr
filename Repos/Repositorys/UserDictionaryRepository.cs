using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class UserDictionaryRepository : BaseInterface<UserDictionary>
    {
        private readonly LnContext _context;

        public UserDictionaryRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(UserDictionary entity)
        {
            _context.UserDictionarys.Add(entity);
        }

        public IEnumerable<UserDictionary> Get()
        {
            return _context.UserDictionarys.ToList();
        }

        public UserDictionary Get(int id)
        {
            return _context.UserDictionarys.Find(id);
        }

        public void Update(UserDictionary entity)
        {
            _context.UserDictionarys.Update(entity);
        }

        public void Delete(int id)
        {
            var userDictionary = Get(id);
            if (userDictionary != null)
                _context.UserDictionarys.Remove(userDictionary);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
