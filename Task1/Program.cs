using System;
using System.IO;

namespace Task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write("Вводите текст: ");
            string text = Console.ReadLine();
            string result = text[0].ToString();

            if (text is null)
            {
                throw new ArgumentNullException(nameof(text), "String is null.");
            }

            if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException("Incorrect format.");
            }

            for (int i = 2; i < text.Length; i++)
            {
                if (text[i - 1] == '\n')
                    result += " " + text[i];
            }

            Console.WriteLine(result);
        }
    }
}