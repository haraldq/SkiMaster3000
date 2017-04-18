using Microsoft.AspNetCore.Mvc;

namespace SkiMaster3000.Controllers
{
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        [HttpGet("[action]")]
        public Answer GetSkiLength()
        {
            return new Answer { SkiLength = 42, Comment = "yabba" };
        }
    }
}
