using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class TermRepository : BaseInterface<Term>
    {
        private readonly LnContext _context;

        public TermRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(Term entity)
        {
            _context.Terms.Add(entity);
        }

        public IEnumerable<Term> Get()
        {
            return _context.Terms.ToList();
        }

        public Term Get(int id)
        {
            return _context.Terms.Find(id);
        }

        public void Update(Term entity)
        {
            _context.Terms.Update(entity);
        }

        public void Delete(int id)
        {
            var term = Get(id);
            if (term != null)
                _context.Terms.Remove(term);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
