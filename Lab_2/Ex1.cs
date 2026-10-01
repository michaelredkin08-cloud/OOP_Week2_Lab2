namespace Lab_2
{
    internal class Ex1
    {
        static void Main(string[] args)
        {
            //File path = "results.txt";
            string path1 = "results.txt"; // Contains the percentages of 7 subjects

            string[] readLines = File.ReadAllLines(path1);



            // Calculate total points and append to the file
            int totalPoints = 0, smallestMark = 100;
            int currentMark = 0;
            for (int i = 0; i < 7; i++)
            {

                int currentGrade = int.Parse(readLines[i]);
                currentMark = PercentageToMarks(currentGrade);

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




            //Display the contents of the file
            foreach (string line in File.ReadAllLines(path1)) // foreach is used here for exercise 2 as well
            {
                Console.WriteLine(line);

            }


        }
        static int PercentageToMarks(int percentage)
        {
            int points;
            
            //Doing it using if 
            if (percentage < 0 || percentage > 100)
            {
                Console.WriteLine("Invalid percentage");
                throw new ArgumentException("Invalid percentage");
            }

            if (percentage >= 90)
                points = 100;
            else if (percentage >= 80)
                points = 88;
            else if (percentage >= 70)
                points = 77;
            else if (percentage >= 60)
                points = 66;
            else if (percentage >= 50)
                points = 56;
            else if (percentage >= 40)
                points = 46;
            else if (percentage >= 30)
                points = 37;
            else
                points = 0;
            return points;

        }
    }
}
