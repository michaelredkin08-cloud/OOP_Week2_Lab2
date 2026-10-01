namespace Lab_2
{
    internal class Ex1
    {
        static void Main(string[] args)
        {
            //File path = "results.txt";
            string path1 = "results.txt";
            
            string[] readLines = File.ReadAllLines(path1);



            // Calculate total points and append to the file
            int totalPoints = 0, smallestGrade = 100;
            for (int i = 0; i < 7; i++)
            {
                
                int currentGrade = int.Parse(readLines[i]);
                totalPoints += currentGrade;//Not secured but not gonna spend time for extra checks now
                
                if (smallestGrade > currentGrade)
                {
                    smallestGrade = currentGrade;
                }
                if (i == 6)
                {
                    int totalPointsToAppend = totalPoints - smallestGrade;
                    File.AppendAllText(path1, totalPointsToAppend + Environment.NewLine);
                }
            }






            //Display the contents of the file
            foreach (string line in File.ReadAllLines(path1))
            {
                Console.WriteLine(line);

            }


        }
    }
}
