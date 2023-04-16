using ObjektorienteradAnalysAssignment.Factories;
using ObjektorienteradAnalysAssignment.Models.DTOs;

namespace ObjektorienteradAnalysAssignment.Models.Entities
{
    public class ArticleEntity
    {
        public Guid Id { get; set; }
        public string ArticleTitle { get; set; } = null!;
        public string ArticleText { get; set; } = null!;

        public static implicit operator ArticleResponse(ArticleEntity entity)
        {
            var res = ArticleResponseFactory.Create();
            res.Id = entity.Id;
            res.ArticleTitle = entity.ArticleTitle;
            res.ArticleText = entity.ArticleText;

            return res;
        }
    }
}
