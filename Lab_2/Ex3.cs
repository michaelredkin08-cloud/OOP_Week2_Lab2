using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_2
{
    internal class Ex3
    {
        static void Main(string[] args)
        {
            
            string path1 = "results.txt"; // Contains the percentages of 7 subjects

            int[] boundaries = [90, 80, 70, 60, 50, 40, 30];// This is the boundaries for the percentage 
            int[] Hmarks = [100, 88, 77, 66, 56, 46, 37, 0];// This is the marks for the high level grades
            int[] Omarks = [56, 46, 37, 28, 20, 12, 0, 0];// This is the marks for the ordinary level grades


            string[] readLines = File.ReadAllLines(path1);
            bool isHighLevel = true; // Assuming all subjects are high level for now


            if (isHighLevel)
            {
                int totalPoints = 0, smallestMark = 100;
                int currentMark = 0;
                for (int i = 0; i < 7; i++)
                {
                    int currentGrade = int.Parse(readLines[i]);
                    currentMark = PercentageToMarks(currentGrade, boundaries, Hmarks, isHighLevel);
                    totalPoints += currentMark;//Not secured but not gonna spend time for extra checks now
                    if (smallestMark > currentMark)
                    {
                        smallestMark = currentMark;
                    }
                    if (i == 6)
                    {
                        int totalPointsToAppend = totalPoints - smallestMark;
                        File.AppendAllText(path1, totalPointsToAppend + Environment.NewLine);
                    }
                }
            }
            else
            {
                // Similar logic for ordinary level subjects
            }



        }
        static int PercentageToMarks(int currentGrade, int[] boundaries,int[] Hmarks, bool isHighLevel)
        {
            int points = 0;
            int iCount = 0;
            bool found = false;
            do
            {
                if (currentGrade >= boundaries[iCount])
                {
                    points = Hmarks[iCount];
                    found = true;
                }
                else
                {
                    iCount++;
                }
            } while (found != true);
            return points;
        }



    }
}
