using System;
using SkiMaster3000.Domain;

namespace SkiMaster3000.Services
{
    public class SkiLengthCalculator
    {
        public Answer Calculate(int age, int length, SkiStyle skistyle)
        {
            int skiLength = length;
            Answer answer = new Answer(new Range(length,length), "");
            if (skistyle == SkiStyle.Classic)
            {
                if (age <= 4)
                    answer = new Answer(new Range(skiLength + 20, skiLength + 20), "");
                else
                    answer = new Answer(new Range(skiLength + 10 + 20, skiLength + 20 + 20), "");
            }
            if (skistyle == SkiStyle.FreeStyle)
            {
                if (age <= 4)
                    answer = new Answer(new Range(skiLength + 10, skiLength + 15), "");
                else
                    answer = new Answer(new Range(skiLength + 10 + 10, skiLength + 20 + 15), "");
            }
            if (answer.SkiLength.Max >= 207 && skistyle == SkiStyle.Classic)
            {
                //answer = new Answer(new Range(answer.SkiLength.Min , 207), "Klassiska skidor tillverkas bara till längder upp till 207cm.");
                answer.Comment = "Klassiska skidor tillverkas bara till längder upp till 207cm.";
                answer.SkiLength.Max = 207;
            }
            if (answer.SkiLength.Min >= 207 && skistyle == SkiStyle.Classic)
            {
                answer.SkiLength.Min = 207;
            }

            return answer;
        }
    }
}