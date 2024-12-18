using FnPrDotnet;
using Microsoft.EntityFrameworkCore;

namespace Repos.Repositories
{
    public class WordListRepository : BaseInterface<WordList>
    {
        private readonly LnContext _context;

        public WordListRepository(LnContext context)
        {
            _context = context;
        }

        public void Create(WordList entity)
        {
            _context.WordLists.Add(entity);
        }

        public IEnumerable<WordList> Get()
        {
            return _context.WordLists.ToList();
        }

        public WordList Get(int id)
        {
            return _context.WordLists.Find(id);
        }

        public void Update(WordList entity)
        {
            _context.WordLists.Update(entity);
        }

        public void Delete(int id)
        {
            var wordList = Get(id);
            if (wordList != null)
                _context.WordLists.Remove(wordList);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
