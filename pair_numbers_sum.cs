/*
C#:
Program that checks all the numbers in an array and retrieves all the ones that give like sum a given target:
Here the initial target is 30.
Solved by Alessandro Silvestri for Microsoft Learn - 2024 <alessandro.silvestri.work@gmail.com>
*/

using System;

namespace myProgram
{
    class Program
    {
        static void Main(string[] arg)
        {
            // creating the inputs
            int target = 30;
            int[] coins = [5, 5, 50, 25, 25, 10, 5];     
            // creating the result array
            int[] twoCoinsResult = TwoCoins(coins, target);
            // display the array content in the form (1,2)
            displayTwoCoinsResult(twoCoinsResult);
        }
        static int[] TwoCoins(int[] coins, int target)
        {
            // I used 2 pointers: start / end that iterate through the array coins looking for pairs of
            // values with sum target(variable)
            bool found = false;
            int end = 0;
            int coinsLength = coins.Length;
            int[] result = [];
            for (int start = 0; start < coinsLength; start++)
            {
                end++;
                do
                {
                    if ((coins[start] + coins[end]) == target)
                    {
                        result = Append(result, start);
                        result = Append(result, end);
                        found = true;
                    }
                    end++;

                } while (end < coinsLength);
                end = start;
            }
            if (!found)
            {
                Console.WriteLine("No two coins make change");
            }
            return result;
        }

        static int[] Append(int[] arr, int i)
        {
            // add a value to an array
            Array.Resize(ref arr, arr.Length + 1);
            arr[arr.Length - 1] = i;
            return arr;
        }

        static void displayTwoCoinsResult(int[] twoCoinsResult)
        {
            // displau the result in the form: (1,2)
            int index = 0;
            int numberOfCycles = (twoCoinsResult.Length / 2);
            for (int i = 0; i < numberOfCycles; i++)
            {
                Console.Write($"{twoCoinsResult[index]},{twoCoinsResult[index + 1]}");
                Console.WriteLine();
                index += 2;
            }
        }
    }
}
