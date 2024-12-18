using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class TermTypeRepository : BaseInterface<TermType>
    {
        private readonly LnContext _context;

        public TermTypeRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(TermType entity)
        {
            _context.TermTypes.Add(entity);
        }

        public IEnumerable<TermType> Get()
        {
            return _context.TermTypes.ToList();
        }

        public TermType Get(int id)
        {
            return _context.TermTypes.Find(id);
        }

        public void Update(TermType entity)
        {
            _context.TermTypes.Update(entity);
        }

        public void Delete(int id)
        {
            var termType = Get(id);
            if (termType != null)
                _context.TermTypes.Remove(termType);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
