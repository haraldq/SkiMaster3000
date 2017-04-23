using SkiMaster3000.Domain;

namespace SkiMaster3000.Controllers
{
    public class AnswerDtoFactory
    {
        public static AnswerDto Create(Answer answer)
        {
            return new AnswerDto
            {
                SkiLengthMax = answer.SkiLength.Max,
                SkiLengthMin = answer.SkiLength.Min,
                Comment = answer.Comment
            };
        }
    }
}