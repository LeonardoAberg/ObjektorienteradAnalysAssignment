using Microsoft.EntityFrameworkCore;
using ObjektorienteradAnalysAssignment.Models.Entities;

namespace ObjektorienteradAnalysAssignment.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ArticleEntity> Articles { get; set; }
    }
}
