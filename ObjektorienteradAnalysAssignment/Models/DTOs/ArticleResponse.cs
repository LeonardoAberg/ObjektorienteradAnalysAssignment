namespace ObjektorienteradAnalysAssignment.Models.DTOs
{
    public class ArticleResponse
    {
        public Guid Id { get; set; }
        public string ArticleTitle { get; set; } = null!;
        public string ArticleText { get; set; } = null!;
    }
}
