using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class ResultRepository : BaseInterface<Result>
    {
        private readonly LnContext _context;

        public ResultRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(Result entity)
        {
            _context.Results.Add(entity);
        }

        public IEnumerable<Result> Get()
        {
            return _context.Results.ToList();
        }

        public Result Get(int id)
        {
            return _context.Results.Find(id);
        }

        public void Update(Result entity)
        {
            _context.Results.Update(entity);
        }

        public void Delete(int id)
        {
            var result = Get(id);
            if (result != null)
                _context.Results.Remove(result);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
