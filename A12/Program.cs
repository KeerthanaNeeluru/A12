using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace A12
{
    internal class Program
    {
        public static int CountWords(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
                return 0;

            string[] words = inputText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
        public static bool ContainsEmailAddresses(string inputText)
        {
            // Regular expression pattern for email validation
            string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";

            // Create a regular expression object with the pattern
            Regex regex = new Regex(emailPattern);

            // Use Matches method to find matches in the input text
            MatchCollection matches = regex.Matches(inputText);

            // Return true if at least one match is found, indicating the presence of an email address
            return matches.Count > 0;
        }
        public static string[] mobile(string inputText)
        {
            // Regular expression pattern for mobile number extraction (10 digits)
            string mobileNumberPattern = @"\b\d{10}\b";

            // Create a regular expression object with the pattern
            Regex regex = new Regex(mobileNumberPattern);

            // Use Matches method to find matches in the input text
            MatchCollection matches = regex.Matches(inputText);

            // Create an array to store the extracted mobile numbers
            string[] mobileNumbers = new string[matches.Count];

            // Extract and store the mobile numbers from the MatchCollection into the array
            for (int i = 0; i < matches.Count; i++)
            {
                mobileNumbers[i] = matches[i].Value;
            }

            return mobileNumbers;
        }
        public static void custom(string inputText, string regexPattern)
        {
            try
            {
                // Create a regular expression object with the custom pattern
                Regex regex = new Regex(regexPattern);

                // Use Matches method to find matches in the input text
                MatchCollection matches = regex.Matches(inputText);

                // Display the matches found
                if (matches.Count > 0)
                {
                    Console.WriteLine("Matches found:");
                    foreach (Match match in matches)
                    {
                        Console.WriteLine(match.Value);
                    }
                }
                else
                {
                    Console.WriteLine("No matches found.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid regular expression: " + ex.Message);
            }
        }
        static void Main(string[] args)
        {
            string userinput ;

           
            Console.WriteLine("Enter any paragraph or text");
            userinput = Console.ReadLine();
            int count= CountWords(userinput);
            Console.WriteLine("Enter Email id");
            bool emailval = ContainsEmailAddresses(userinput);
            string[] mobileNumbers = mobile(userinput);

            //display results
            Console.WriteLine("Results");
            Console.WriteLine("Number of word in the user input text is : "+count);
            if (emailval)
            {
                Console.WriteLine("The user text contain email address");
            }
            else
            {
                Console.WriteLine("The user text does not contain email address ");
            }
            Console.WriteLine("Extracted mobile numbers:");
            foreach (string number in mobileNumbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine("Enter a custom regular expression to search for:");
            string pattern = Console.ReadLine();
            custom(userinput, pattern);
            Console.ReadKey();
        }
    }
}
