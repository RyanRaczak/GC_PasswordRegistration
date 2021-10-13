using System;
using System.Collections.Generic;

namespace GC_PasswordRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("::Password Registration::\n\n");
            bool userContinue = true;
            List<string> userName = new List<string>();
            List<string> userPass = new List<string>();
            while (userContinue)
            {
                Console.WriteLine("::Please select an option from the menu::");
                string input = GetInput("\n1) Register a Username and Password\n" +
                    "2) Print Database\n" +
                    "3) Exit\n:");
                switch (input)
                {
                    case "1":
                        RegisterUsername(userName);
                        RegisterPassword(userPass);
                        break;
                    case "2":
                        PrintUserPass(userName, userPass);
                        break;
                    case "3":
                        userContinue = false;
                        Console.WriteLine("\nGoodbye...");
                        break;
                    default:
                        Console.WriteLine("\nInvalid input...");
                        break;
                }

            }
        }
        public static List<string> RegisterUsername(List<string> userName)
        {
            List<string> rule = new List<string>();
            string[] forbiddenWords = { "Admin", "admin", "God", "god", "Master", "master" };
            int upperCount = 0, lowerCount = 0, numCount = 0, forbiddenCount = 0; //Count how many letters and numbers in a username
            string userInput = GetInput("\nPlease input a username. A username...\n" +
                "~Must have letters and numbers\n" +    //validated
                "~Must have at least 5 letters\n" +     //validated
                "~Have a minimum of 7 characters\n" +   // validated
                "~Have a maximum of 12 characters\n" +  // validated
                "~And may not contain \"Admin\", \"Master\", or \"God\"\n\n:"); //validated
            //Searching for numbers
            foreach (var character in userInput)
            {
                if (character >= '0' && character <= '9')
                {
                    numCount++;
                }
            }

            //Searching for lowercase
            foreach (var character in userInput)
            {
                if (character >= 'a' && character <= 'z')
                {
                    lowerCount++;
                }
            }

            //Searching for uppercase
            foreach (var character in userInput)
            {
                if (character >= 'A' && character <= 'Z')
                {
                    upperCount++;
                }
            }

            //Searching for banned words
            foreach (var word in forbiddenWords)
            {
                if (userInput.Contains(word))
                {
                    forbiddenCount++;
                }
            }

            //Searching for duplicate names
            foreach (var name in userName)
            {
                if (name == userInput)
                {
                    rule.Add("Rule Broken: Duplicate name found");
                    break;
                }
            }
            //Console.WriteLine($"{forbiddenCount} forbidden words were found");
            //Console.WriteLine($"{upperCount} upper case letters were found");
            //Console.WriteLine($"{lowerCount} lower case letters were found");
            //Console.WriteLine($"{numCount} numbers were found");

            //Adding broken rules
            if (userInput.Length < 7)
            {
                rule.Add("Rule Broken: Did not meet minimum characters");
            }
            if (userInput.Length > 12)
            {
                rule.Add("Rule Broken: Exceeded maximum characters");
            }
            if (upperCount <= 0 && lowerCount <= 0)
            {
                rule.Add("Rule Broken: Did not include letters");
            }
            if (numCount <= 0)
            {
                rule.Add("Rule Broken: Did not include numbers");
            }
            if (forbiddenCount > 0)
            {
                rule.Add("Rule Broken: Used forbidden words");
            }

            //Checks to see if any rules were broken. Will only return when no rules broken
            if (rule.Count == 0)
            {
                userName.Add(userInput);
                return userName;
            }
            else
            {
                Console.WriteLine();
                foreach (var broken in rule)
                {
                    Console.WriteLine(broken);
                }
                return RegisterUsername(userName);
            }
        }
        public static List<string> RegisterPassword(List<string> userPass)
        {
            List<string> rule = new List<string>();
            char[] specialCharacters = { '!', '@', '#', '$', '%', '^', '&', '*' };
            int upperCount = 0, lowerCount = 0, numCount = 0, specialCount = 0; //Count how many letters and numbers in a username
            string userInput = GetInput("\nPlease input a password. A password must contain...\n" +
                "~At least one lowercase letter\n" + //validated
                "~At least one uppercase letter\n" + //validated
                "~At least one number\n" +           //validated
                "~A minimum of 7 characters\n" +     //validated
                "~A maximum of 12 characters\n" +    //validated
                "~And one special character(!,@,#,...)\n\n:"); //validated

            //Searching for numbers
            foreach (var character in userInput)
            {
                if (character >= '0' && character <= '9')
                {
                    numCount++;
                }
            }

            //Searching for lowercase
            foreach (var character in userInput)
            {
                if (character >= 'a' && character <= 'z')
                {
                    lowerCount++;
                }
            }

            //Searching for uppercase
            foreach (var character in userInput)
            {
                if (character >= 'A' && character <= 'Z')
                {
                    upperCount++;
                }
            }

            //Searching for banned words
            foreach (var character in specialCharacters)
            {
                if (userInput.Contains(character))
                {
                    specialCount++;
                }
            }
            //Console.WriteLine($"{specialCount} special characters were found");
            //Console.WriteLine($"{numCount} numbers were found");
            //Console.WriteLine($"{upperCount} upper case letters were found");
            //Console.WriteLine($"{lowerCount} lower case letters were found");

            //Adding broken rules
            if (userInput.Length < 7)
            {
                rule.Add("Rule Broken: Did not meet minimum characters");
            }
            if (userInput.Length > 12)
            {
                rule.Add("Rule Broken: Exceeded maximum characters");
            }
            if (upperCount <= 0)
            {
                rule.Add("Rule Broken: Did not include uppercase letters");
            }
            if (lowerCount <= 0)
            {
                rule.Add("Rule Broken: Did not include lowercase letters");
            }
            if (numCount <= 0)
            {
                rule.Add("Rule Broken: Did not include numbers");
            }
            if (specialCount <= 0)
            {
                rule.Add("Rule Broken: No special characters");
            }

            //Checks to see if any rules were broken. Will only return when no rules broken
            if (rule.Count == 0)
            {
                userPass.Add(userInput);
                return userPass;
            }
            else
            {
                Console.WriteLine();
                foreach (var broken in rule)
                {
                    Console.WriteLine(broken);
                }
                return RegisterPassword(userPass);
            }
        }
        public static void PrintUserPass(List<string> userName, List<string> userPass)
        {
            Console.WriteLine("\nDoing the unthinkable and printing all usernames and passwords...\n");

            if (userName.Count > 0 && userPass.Count > 0)
            {
                for (int i = 0; i < userName.Count; i++)
                {
                    Console.WriteLine($"Username: {userName[i]}\tPassword: {userPass[i]}");
                }
            }
            else
            {
                Console.WriteLine("The database is currently empty...");
            }


            Console.WriteLine();

        }
        public static string GetInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

    }
}
