using Microsoft.AspNetCore.Mvc;

namespace ObjektorienteradAnalysAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentTypesController : ControllerBase
    {
        [HttpPost]
        public void Create([FromBody] string value)
        {
        }
    }
}
