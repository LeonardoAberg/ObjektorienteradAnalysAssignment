using ObjektorienteradAnalysAssignment.Models;
using ObjektorienteradAnalysAssignment.Models.Entities;

namespace ObjektorienteradAnalysAssignment.Factories
{
    public class ArticleEntityFactory
    {
        public static ArticleEntity Create()
        {
            return new ArticleEntity()
            {
                Id = Guid.NewGuid()
            };
        }
    }
}
