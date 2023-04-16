using ObjektorienteradAnalysAssignment.Factories;
using ObjektorienteradAnalysAssignment.Models.Entities;

namespace ObjektorienteradAnalysAssignment.Models.DTOs
{
    public class ArticleRequest
    {
        public string ArticleTitle { get; set; } = null!;
        public string ArticleText { get; set; } = null!;

        public static implicit operator ArticleEntity(ArticleRequest articleReuqest)
        {
            var articleEntity = ArticleEntityFactory.Create();

            articleEntity.ArticleTitle = articleReuqest.ArticleTitle;
            articleEntity.ArticleText = articleReuqest.ArticleText;

            return articleEntity;
        }
    }
}
