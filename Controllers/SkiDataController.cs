using Microsoft.AspNetCore.Mvc;

namespace SkiMaster3000.Controllers
{
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        //[HttpGet("[action]")]
        //public Answer GetSkiLength()
        //{
        //    return new Answer { SkiLength = 42, Comment = "yabba" };
        //}

        [HttpGet("[action]/{length}")]
        public Answer GetSkiLength(string length)
        {
            return new Answer { SkiLength = int.Parse(length), Comment = "yabba" };
        }
    }
}
