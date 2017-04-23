using System;
using SkiMaster3000.Domain;

namespace SkiMaster3000.Services
{
    public class SkiLengthCalculator : ISkiLengthCalculator
    {
        public Answer Calculate(int age, int length, SkiStyle skistyle)
        {
            if(age < 0 || length < 0)
                throw new ArgumentException("Age and length cannot be a negative number.");

            int skiLength = length;
            Answer answer = new Answer(new Range(length,length), "");
            if (skistyle == SkiStyle.Classic)
            {
                answer = new Answer(new Range(skiLength + 20, skiLength + 20), "");

                if (age >= 5 && age <= 8)
                {
                    answer.SkiLength.Min += 10;
                    answer.SkiLength.Max += 20;
                }

            }
            if (skistyle == SkiStyle.FreeStyle)
            {
                answer = new Answer(new Range(skiLength + 10, skiLength + 15), 
                    "Enligt tävlingsreglerna får inte skidan understiga kroppslängden med mer än 10cm.");
                if (age >= 5 && age <= 8)
                {
                    answer.SkiLength.Min += 10;
                    answer.SkiLength.Max += 20;
                }
            }
            if (answer.SkiLength.Max >= 207 && skistyle == SkiStyle.Classic)
            {
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

    public interface ISkiLengthCalculator
    {
        Answer Calculate(int age, int length, SkiStyle skistyle);
    }
}