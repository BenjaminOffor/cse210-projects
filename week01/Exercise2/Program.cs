using System;

class Program
{
    static void Main(string[] args)
    {
      // Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        int grade = int.Parse(Console.ReadLine());
        
        string letter = "";
        string sign = "";
        
        // Determine the letter grade
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        
        // Determine the sign (+ or -)
        int lastDigit = grade % 10;
        
        if (letter != "A" && letter != "F") // A+ does not exist, and F has no +/-
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }
        else if (letter == "A" && lastDigit < 3)
        {
            sign = "-"; // A- is valid
        }
        
        // Display the final letter grade
        Console.WriteLine($"Your letter grade is: {letter}{sign}");
        
        // Check if the student passed or failed
        if (grade >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Don't give up! Keep working hard for next time.");
        }
    }
}