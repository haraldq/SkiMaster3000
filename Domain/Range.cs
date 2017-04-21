namespace SkiMaster3000.Domain
{
    public class Range
    {
        public Range(int max, int min)
        {
            Max = max;
            Min = min;
        }

        public int Max { get; }
        public int Min { get; }
    }
}