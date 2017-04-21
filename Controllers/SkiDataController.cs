using Microsoft.AspNetCore.Mvc;

namespace SkiMaster3000.Controllers
{
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        [HttpGet("[action]/{length}/{age}/{skistyle}")]
        public AnswerDto GetSkiLength(int length, int age, string skistyle)
        {
            return new AnswerDto { SkiLengthMax = length + age, SkiLengthMin = 1, Comment = "yabba" + skistyle };
        }
    }

    public class AnswerDto
    {
        public int SkiLengthMax { get; set; }
        public int SkiLengthMin { get; set; }
        public string Comment { get; set; }
    }
}
