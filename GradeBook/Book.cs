using System;
using System.Collections.Generic;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
       public NamedObject(string name)
        {
            Name = name;
        }

        public string Name
        {
            get;
            set;
        }
    }

    public class Book : NamedObject // Book IS-A named object
    {
        public Book(string name) : base(name) // This is an explicit Constructor is optional. Cannot have a return type
        {
            grades = new List<double>();
            Name = name; // this object (class). Used to identify the properties in this class/object
        }

        public void AddGrade(char Letter)
        {
            switch (Letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }
        public void AddGrade(double grade)
        {
            if(grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if(GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs ());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
                       
        }

        public event GradeAddedDelegate GradeAdded; // can use Book.GradeAdded

        public Statistics GetStatistics()   // return an object of type Statistics
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            //foreach (var grade in grades) BEST to USE
            //{
            //    result.Low = Math.Min(grade, result.Low);  // returns the highest number 
            //    result.High = Math.Max(grade, result.High);
            //    result.Average += grade;
            //}


            ///* do-while LOOP */
            //var index = 0;
            //do
            //{
            //    result.Low = Math.Min(grades[index], result.Low);  // returns the highest number 
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //} while (index < grades.Count); // remember, the collection starts at 0

            ///* while LOOP */
            //var index = 0;
            //while (index < grades.Count) // remember, the collection starts at 0    
            //{
            //    result.Low = Math.Min(grades[index], result.Low);  // returns the highest number 
            //    result.High = Math.Max(grades[index], result.High);
            //    result.Average += grades[index];
            //    index += 1;
            //} 

            /* For LOOP */
            for (var index = 0; index < grades.Count; index++) // FOR EACH Loop is better
            {
                //if(grades[index] == 42.1)
                //{
                //    continue; // can use break to break the loop
                //}
                result.Low = Math.Min(grades[index], result.Low);  // returns the highest number 
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
            }
            result.Average /= grades.Count;

            if (result.Average >= 90.0)
            {
                result.Letter = 'A';
            }
            else if (result.Average >= 80.0)
            {
                result.Letter = 'B';
            }
            else if (result.Average >= 70.0)
            {
                result.Letter = 'C';
            }
            else if (result.Average >= 60.0)
            {
                result.Letter = 'D';
            }
            else
            {
                result.Letter = 'F';
            }

            //switch (result.Average)
            //{
            //    case var d when d >= 90.0:
            //        result.Letter = "A";
            //        break;

            //    case var d when d >= 80.0:
            //        result.Letter = 'B';
            //        break;

            //    case var d when d >= 70.0:
            //        result.Letter = 'C';
            //        break;

            //    case var d when d >= 60.0:
            //        result.Letter = 'D';
            //        break;

            //    default:
            //        result.Letter = 'F';
            //        break;
            //}

            return result;
        }

        private List<double> grades; // this is a field, cant use var      

        //public string Name
        //{
        //    get;
        //    set; // read only
        //} // same as below. In this case, user cannot change the name
        //string category = "Science"; // readonly fields can only be assigned in constructors


        public const string CATEGORY = "Science"; // readonly fields can only be assigned in constructors

        //public string Name // uppercase when properties are public
        //{
        //    get
        //    {
        //        return name;
        //    }
        //    set
        //    {
        //        if (!String.IsNullOrEmpty(value))
        //        {
        //            name = value; // In every SETTER, there is an implicit param named value, which
        //                          // is the incoming value from the program
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException($"You attempted to set a name {nameof(Name)}");
        //        }
        //    }
        //}
        //private string name;
    }
}
