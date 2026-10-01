using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    internal class Ex5
    {
        static void Main(string[] args)
        {

            string path1 = "results.txt"; // New file created / overwritten each run

            int[] boundaries = [90, 80, 70, 60, 50, 40, 30];// This is the boundaries for the percentage 
            int[] Hmarks = [100, 88, 77, 66, 56, 46, 37, 0];// This is the marks for the high level grades
            int[] Omarks = [56, 46, 37, 28, 20, 12, 0, 0];// This is the marks for the ordinary level grades

            var (name, number, level, subjects, grades) = userInputMethod(); // for future use for input method

            bool isHighLevel = false; // checking if it is high level or ordinary level subject
            if (level == "H")
            {
                isHighLevel = true;
            }

            int[] points = new int[7]; // marks for each subject
            int totalPoints = 0, smallestMark = 101;//Anything will be smaller than 101 so it will be replaced by the first mark
            int currentMark = 0;

            for (int i = 0; i < 7; i++)
            {
                if (isHighLevel)
                {
                    currentMark = PercentageToMarks(grades[i], boundaries, Hmarks);
                }
                else
                {
                    currentMark = PercentageToMarks(grades[i], boundaries, Omarks);
                }

                points[i] = currentMark;
                totalPoints += currentMark;
                if (smallestMark > currentMark)
                {
                    smallestMark = currentMark;
                }
            }
            int totalPointsToAppend = totalPoints - smallestMark; // best 6 of 7

            // Keep all the output lines in an array
            string[] output = new string[11];
            output[0] = "Student name: " + name;
            output[1] = "Student number: " + number;
            output[2] = "Level: " + level;
            for (int i = 0; i < 7; i++)
            {
                output[i + 3] = subjects[i] + ": " + grades[i] + "% -> " + points[i] + " points";
            }
            output[10] = "Total points (best 6): " + totalPointsToAppend;

            File.WriteAllLines(path1, output); // creates the file and overwrites it each time

            foreach (string line in File.ReadAllLines(path1)) // foreach is used here for exercise 2 as well
            {
                Console.WriteLine(line);
            }

        }
        static int PercentageToMarks(int currentGrade, int[] boundaries, int[] marks)
        {
            int points = 0;
            int iCount = 0;
            bool found = false;
            do
            {
                if (iCount == boundaries.Length) // below the lowest boundary
                {
                    points = marks[iCount];
                    found = true;
                }
                else if (currentGrade >= boundaries[iCount])
                {
                    points = marks[iCount];
                    found = true;
                }
                else
                {
                    iCount++;
                }
            } while (found != true);
            return points;
        }

        //INPUT METHOD --- INPUT METHOD --- INPUT METHOD --- 

        static (string studentName, string StudentNumber, string level, string[] subjects, int[] grades) userInputMethod()
        {
            string studentName, StudentNumber, level;
            string[] subjects = new string[7];
            int[] grades = new int[7];

            Console.WriteLine("Enter student name:");
            studentName = Console.ReadLine();

            Console.WriteLine("Enter student number:");
            StudentNumber = Console.ReadLine();

            Console.WriteLine("Enter level (H or O):");
            level = Console.ReadLine().ToUpper();

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"Subject {i + 1} name:");
                subjects[i] = Console.ReadLine();

                Console.WriteLine($"Subject {i + 1} percentage:");
                while (!int.TryParse(Console.ReadLine(), out grades[i]) || grades[i] < 0 || grades[i] > 100)
                {
                    Console.WriteLine("Invalid percentage, try again (0-100):");
                }
            }

            return (studentName, StudentNumber, level, subjects, grades);
        }
    }
}