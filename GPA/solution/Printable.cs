using System;
using System.Text.RegularExpressions;


namespace GPA.solution
{
    public class PrintTable
    {
        //declaration of variables used.
        public string print_all = "";
        public string course;
        public int courseUnit;
        public double actualScore;
        public char grade;
        public int gradeUnit;
        public int weightPoint;
        public string remark;
        public double gpa;

        public int totalCourseUnitRegistered = 0;
        public int totalCourseUnitPassed = 0;
        public int totalWeightPoint = 0;
        public string n;
        private int num;
        private double num2;
        public string rawcourseunit,rawscore;


        public void MyTable()
        {
            //Receiving the number of courses the user would want to check.
            //The do while will keep running until user inputs an integer.
            try {

                do
                {
                    Console.Clear();
                    Console.Write("Hello and welcome to your favourite GPA CALCULATOR, Please Input the number of courses you would like to check:NOTE!\nYou would only proceed if your input is a number.Thank you !\n Input it Here:      ");
                    n = Console.ReadLine();
                }
                while (!int.TryParse(n, out num));


                //converting the above input to integer
                int totalcourses = int.Parse(n);


                //the counter helps to make the app more interactive.
                int counter = 1;


                //the length of the loop is determined by the user's input above. 
                //all do-while loops below will ensure the code keeps requesting for the correct user input and will not proceed until the correct datatype is supplied
                for (int i = 0; i < totalcourses; i++)
                {
                    do
                    {
                        Console.Clear();
                        Console.Write($"Press 'q' to exit console.\n\n");
                        Console.Write($"Enter course {counter}:  ");
                        course = Console.ReadLine();
                        if (course=="q" || course == "Q") { System.Environment.Exit(0); }
                    } while (course == "" );
                    //!Regex.IsMatch(course, @"^[A-Za-z0-9]$")



                    do
                    {
                        Console.Clear();
                        Console.Write($"Press 'q' to exit console.\n\n");
                        Console.Write($"Ensure the course unit for  {course} is within range 1 - 5:   ");
                        rawcourseunit = Console.ReadLine();
                        if (rawcourseunit == "q" || rawcourseunit == "Q") { System.Environment.Exit(0); }
                    } while (!int.TryParse(rawcourseunit, out num ) || (int.Parse(rawcourseunit) < 1) || (int.Parse(rawcourseunit) > 5) );
                     courseUnit = int.Parse (rawcourseunit);                                       


                  do
                    {
                        Console.Clear();
                        Console.Write($"Press 'q' to exit console.\n\n");
                        Console.Write($"Ensure the score of {course} is within range 0 - 100:  ");
                        rawscore = Console.ReadLine();
                        if (rawscore == "q" || rawscore == "Q") { System.Environment.Exit(0); }
                    } while (!Double.TryParse(rawscore, out num2) || double.Parse(rawscore) < 0 || double.Parse(rawscore) > 100);
                    actualScore = Convert.ToDouble(rawscore);


                    if (actualScore >= 70 && actualScore <= 100)
                    {
                        grade = 'A';
                        gradeUnit = 5;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Excellent";
                    }
                    else if (actualScore >= 60 && actualScore < 70)
                    {
                        grade = 'B';
                        gradeUnit = 4;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Very Good";
                    }
                    else if (actualScore >= 50 && actualScore < 60)
                    {
                        grade = 'C';
                        gradeUnit = 3;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Good";
                    }
                    else if (actualScore >= 45 && actualScore < 50)
                    {
                        grade = 'D';
                        gradeUnit = 2;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Fair";
                    }
                    else if (actualScore >= 40 && actualScore < 45)
                    {
                        grade = 'E';
                        gradeUnit = 1;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Pass";
                    }
                    else if (actualScore >= 0 && actualScore < 39)
                    {
                        grade = 'F';
                        gradeUnit = 0;
                        weightPoint = courseUnit * gradeUnit;
                        remark = "Fail";
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The inputed Number is out of range");
                        break;
                    }

                    // Collecting all print statements into variable "print_all". Each print statement is being appended to the previous print statement until iteration is concluded
                    print_all = print_all + $" |    {course,-14}|     {courseUnit,-12}|     {grade,-6}|    {gradeUnit,-11}|    {weightPoint,-11}|    {remark,-10}|\n";
                    counter += 1;

                    //Calculating the total course units registered
                    totalCourseUnitRegistered = totalCourseUnitRegistered + courseUnit;


                    // Calculating the total course unit passed
                    if (grade != 'F')
                    {
                        totalCourseUnitPassed = totalCourseUnitPassed + courseUnit;
                    }


                    //Calculating the total weight point
                    totalWeightPoint = totalWeightPoint + weightPoint;
                }

                //GPA FORMULAR
                gpa = totalWeightPoint / totalCourseUnitRegistered;
                //printing all 
                Console.Clear() ;
                Console.WriteLine(" |------------------|-----------------|-----------|---------------|---------------|--------------|");
                Console.WriteLine(" | COURSE & CODE    | COURSE UNIT     | GRADE     | GRADE-UNIT    | WEIGHT Pt     | REMARK       |");
                Console.WriteLine(" |------------------|-----------------|-----------|---------------|---------------|--------------|");
                Console.WriteLine($"{print_all}\n\n");
                Console.WriteLine($"Total course Unit registered is {totalCourseUnitRegistered}");
                Console.WriteLine($"Total course Unit passed is {totalCourseUnitPassed}");
                Console.WriteLine($"Total Weight point is {totalWeightPoint}");
                Console.WriteLine($"GPA is {gpa:F2}");
            }
            catch ( Exception e ) { Console.WriteLine(e.Message); }
            finally { Console.WriteLine("\nThanks for using our GPA app!.\nPlease donot forget to visit our website for more useful apps at theo-neku@netlify.app. ");  }
            }

    }
}
