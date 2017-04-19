using Microsoft.AspNetCore.Mvc;

namespace SkiMaster3000.Controllers
{
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        [HttpGet("[action]/{length}/{age}/{skistyle}")]
        public Answer GetSkiLength(int length, int age, string skistyle)
        {
            return new Answer { SkiLength = length + age, Comment = "yabba" + skistyle };
        }
    }
}
