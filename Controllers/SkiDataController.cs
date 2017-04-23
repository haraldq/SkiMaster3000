using Microsoft.AspNetCore.Mvc;
using SkiMaster3000.Domain;
using SkiMaster3000.Services;

namespace SkiMaster3000.Controllers
{
    [Route("api/[controller]")]
    public class SkiDataController : Controller
    {
        private readonly ISkiLengthCalculator _skiLengthCalculator;

        public SkiDataController(ISkiLengthCalculator skiLengthCalculator)
        {
            _skiLengthCalculator = skiLengthCalculator;
        }

        [HttpGet("[action]/{length}/{age}/{skistyle}")]
        public AnswerDto GetSkiLength(int length, int age, SkiStyle skistyle)
        {
            return AnswerDtoFactory.Create(_skiLengthCalculator.Calculate(age, length, skistyle));
        }
    }
}
