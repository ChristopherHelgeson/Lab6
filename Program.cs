using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6___strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string againYN = "y";
            while (againYN == "y" || againYN == "Y")
            {

                //Get string from user
                string userInput = GetUserInput();
                int userInputLength = userInput.Length;
                int spaces = CountSpaces(userInput);

                //Change input string to all lowercase
                userInput = ConvertToLower(userInput);

                char[] userInputAsCharArray = ConvertStringToCharArray(userInput);

                string[] userInputWordArray = BuildWordsFromCharArray(userInputLength, spaces, userInputAsCharArray);

                Console.WriteLine("\nYour input translated to Pig Latin is: \n");
                for (int i = 0; i < spaces; i++)
                {
                    int firstVowelIndex = FindFirstVowel(userInputWordArray[i]);
                    TranslateToPig(firstVowelIndex, userInputWordArray[i]);
                }

                Console.Write("\n\nWould you like to translate another entry? (Y/N): ");
                againYN = Console.ReadLine();
            }
        }

        public static void PrintTitle()
        {
            Console.Clear();
            Console.WriteLine("Welcome to to the Pig Latin Translator!\n");
        }

        public static string GetUserInput()
        {
            string x ="";
            while (x == "")
            {
                PrintTitle();
                Console.Write("Enter a word, phrase, or sentence to be translated: ");
                x = Console.ReadLine();
                //Add space at end so BuildWordsFromCharArray method works.
                x = x + " ";
            }
            return x;
        }

        public static bool IsOnlyLetters(string x)
        {
            char[] userCharArray = x.ToArray();
            bool answer = true;
            foreach (char chr in userCharArray)
            {
                if (!char.IsLetter(chr))
                {
                    answer = false;
                }
            }
            return answer;
        }

        public static int FindFirstVowel(string x)
        {
            /* This method looks for "a", then "e", etc., in the string
            and returns the lowest value greater than -1 (not found) */
            string[] vowels = { "a", "e", "i", "o", "u" };
            int[] firstIndexOfEach = new int[5];
            int firstVowelIndex = x.Length;
            for (int i = 0; i<5; i++)
            {
                firstIndexOfEach[i] = x.IndexOf(vowels[i]);
                if (firstIndexOfEach[i] > -1 && firstIndexOfEach[i] < firstVowelIndex)
                {
                    firstVowelIndex = firstIndexOfEach[i];
                }            
            }
            return firstVowelIndex;        
        }

        public static int CountSpaces(string x)
        {
            int spaces = x.Split(' ').Length - 1;
            return spaces;
        }

        public static char[] ConvertStringToCharArray(string x)
        {
            char[] userInputAsCharArray = x.ToCharArray();
            //foreach (char ch in userInputAsCharArray)
            //{
            //    Console.WriteLine(ch);
            //}
            return userInputAsCharArray;
        }

        public static string[] BuildWordsFromCharArray(int length, int spaces, char[] x)
        {
            string[] userInputAsWordArray = new string[spaces];
            char s = char.Parse(" ");
            string currentWord = "";
            int word = -1;
            for (int i = 0; i<length; i++)
            {
                if (x[i] != s)
                {
                    currentWord = currentWord + x[i];
                }
                else
                {
                    word += 1;
                    userInputAsWordArray[word] = currentWord;
                    currentWord = "";
                }             
            }
            return userInputAsWordArray;
        }

        public static string PutConsonantsAtEnd(int firstVowelIndex, string userInput)
        {
            string consonants = userInput.Substring(0, (firstVowelIndex));
            string withoutLeadingConsonants = userInput.Substring(firstVowelIndex);
            string consonantsAtEnd = withoutLeadingConsonants + consonants;
            return consonantsAtEnd;
        }

        public static string ConvertToLower(string x)
        {
            x = x.ToLower();
            return x;
        }

        public static string ConvertToUpper(string x)
        {
            x = x.ToUpper();
            return x;
        }

        public static void TranslateToPig(int firstVowelIndex, string userInput)
        {
            if (IsOnlyLetters(userInput) && firstVowelIndex == 0)
            {
                userInput = userInput + "way";
            }
            else if (IsOnlyLetters(userInput) && firstVowelIndex > 0)
            {
                userInput = PutConsonantsAtEnd(firstVowelIndex, userInput);
                userInput = userInput + "ay";
            }
            Console.Write(userInput + " ");
        }
    }
}
