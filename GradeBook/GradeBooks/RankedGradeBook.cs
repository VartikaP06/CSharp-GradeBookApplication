using GradeBook.Enums;
using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked grading requires at least 5 students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var averageGrades = Students.OrderByDescending(x => x.AverageGrade).Select(x => x.AverageGrade).ToList();
            char result;
            if(averageGrade >= averageGrades[threshold - 1])
            {
                result = 'A';
            }
            if (averageGrade >= averageGrades[threshold * 2 - 1])
            {
                result = 'B';
            }
            if (averageGrade >= averageGrades[threshold * 3 - 1])
            {
                result = 'C';
            }
            if (averageGrade >= averageGrades[threshold * 4 - 1])
            {
                result = 'D';
            }
            else
            {
                result = 'F';
            }
            return result;
        }
    }
}