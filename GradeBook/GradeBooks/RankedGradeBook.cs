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
            else if (averageGrade >= averageGrades[threshold * 2 - 1])
            {
                result = 'B';
            }
            else if (averageGrade >= averageGrades[threshold * 3 - 1])
            {
                result = 'C';
            }
            else if (averageGrade >= averageGrades[threshold * 4 - 1])
            {
                result = 'D';
            }
            else
            {
                result = 'F';
            }
            return result;
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            
            base.CalculateStudentStatistics(name);
        }
    }
}