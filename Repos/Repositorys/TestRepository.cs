using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class TestRepository : BaseInterface<Test>
    {
        private readonly LnContext _context;

        public TestRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(Test entity)
        {
            _context.Tests.Add(entity);
        }

        public IEnumerable<Test> Get()
        {
            return _context.Tests.ToList();
        }

        public Test Get(int id)
        {
            return _context.Tests.Find(id);
        }

        public void Update(Test entity)
        {
            _context.Tests.Update(entity);
        }

        public void Delete(int id)
        {
            var test = Get(id);
            if (test != null)
                _context.Tests.Remove(test);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
