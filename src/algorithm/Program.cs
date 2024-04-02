using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm
{
    internal class Program
    {
        static void miniMaxSum(int[] arr)
        {
            long minSum = long.MaxValue;
            long maxSum = long.MinValue;
            long totalSum = 0;

            foreach (int num in arr)
            {
                totalSum += num;
                if (num < minSum)
                    minSum = num;
                if (num > maxSum)
                    maxSum = num;
            }

            long minPossibleSum = totalSum - maxSum;
            long maxPossibleSum = totalSum - minSum;

            Console.WriteLine($"{minPossibleSum} {maxPossibleSum}");
        }

        static void Main(string[] args)
        {
            string[] arrItems = Console.ReadLine().Split(' ');
            int[] arr = Array.ConvertAll(arrItems, int.Parse);
            miniMaxSum(arr);
        }
    }
}
