namespace SkiMaster3000.Domain
{
    public class Range
    {
        public Range(int min, int max)
        {
            Max = max;
            Min = min;
        }

        public int Max { get; set; }
        public int Min { get; set; }
    }
}