using Microsoft.EntityFrameworkCore;
using ObjektorienteradAnalysAssignment.Contexts;
using ObjektorienteradAnalysAssignment.Models.Entities;
using System.Linq.Expressions;

namespace ObjektorienteradAnalysAssignment.Repositories
{
    public class ArticleRepository
    {
        private readonly DataContext _context;

        public ArticleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ArticleEntity> CreateAsync(ArticleEntity articleEntity)
        {
            _context.Add(articleEntity);
            await _context.SaveChangesAsync();
            return articleEntity;
        }

        public async Task<ArticleEntity> GetAsync(Expression<Func<ArticleEntity, bool>> predicate)
        {
            var entity = await _context.Articles.FirstOrDefaultAsync(predicate);
            return entity!;
        }

        public async Task<IEnumerable<ArticleEntity>> GetAllAsync()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task Put(ArticleEntity article)
        {
            _context.Entry(article).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                throw new Exception("Article not found");
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
        }
    }
}
