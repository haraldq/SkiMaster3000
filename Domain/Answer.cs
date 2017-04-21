namespace SkiMaster3000.Domain
{
    public class Answer
    {
        public Answer(Range skiLength, string comment)
        {
            SkiLength = skiLength;
            Comment = comment;
        }

        public Range SkiLength { get; }
        public string Comment { get; }
    }
}