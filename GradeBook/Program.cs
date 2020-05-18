using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new InMemoryBook("Anelisa's Grades InMemoryBook");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);
            
            var stats = book.GetStatistics(); // Ctrl  + . would autocreate the method in the InMemoryBook class

            Console.WriteLine(InMemoryBook.CATEGORY); // Class name plus Const with CONSTANTS
            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is: {stats.High}");
            Console.WriteLine($"The average of the values is {stats.Average:N1}!");
            Console.WriteLine($"The letter grade is {stats.Letter}");
            Console.ReadLine();
        }

        private static void EnterGrades(Book book)
        {
            
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}


//var grades = new List<double>() { 12.7, 10.3, 6.11, 4.1 }; // list of type double
//grades.Add(56.1);

//var result = 0.0;

//foreach (var number in grades)
//{
//    result += number;
//}
//result /= grades.Count; // same as result = result / grades.Count;
//Console.WriteLine($"The average grade is: {result:N1}");