using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PalindromeSubstring
{
    class Program
    {
        static void Main(string[] args)
        {
            var scanner = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            List<string> palindromes = new List<string>(100);
            string input;
            bool odd, even;
            for (int i = 0; i < 100; i++)
            {
                input = scanner.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    break;
                }
                for (int j = 1; j < input.Length - 1; j++)
                {
                    odd = true;
                    even = true;
                    for (int k = 1; k + j - 1 < input.Length; k++)
                    {
                        if (j - k < 0)
                        {
                            break;
                        }
                        if (even && j + k < input.Length && input[j + k] == input[j - k])
                        {
                            palindromes.Add(input.Substring(j - k, 2 * k + 1));
                        }
                        else
                        {
                            even = false;
                        }
                        if (odd && j + k - 1 > 0 && input[j + k - 1] == input[j - k])
                        {
                            palindromes.Add(input.Substring(j - k, 2 * k));
                        }
                        else
                        {
                            odd = false;
                        }

                        if (!odd && !even)
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine(string.Join("\n", palindromes.Distinct().OrderBy(q => q)));
                palindromes.Clear();
                Console.WriteLine();
            }
        }
    }
}