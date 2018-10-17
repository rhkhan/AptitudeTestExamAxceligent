using System;
using System.Collections.Generic;

namespace SumOfBiggestNeighbor
{

    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);
            Program p = new Program();
            Console.WriteLine(p.Challenge(array));

            Console.Read();
        }

        public int Challenge(int[] input)
        {
            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();
            for (int i = 0; i < input.Length; i++)
                numberDictionary[input[i]] = 0;

            int max = int.MinValue; // get max value
            for (int i = 0; i < input.Length; i++)
            {
                numberDictionary[input[i]] = numberDictionary[input[i]] + 1;
                if (max < numberDictionary[input[i]])
                    max = numberDictionary[input[i]];
            }

            List<int> nList = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (numberDictionary[input[i]]>=max-1)
                {
                    nList.Add(input[i]);
                }
            }

            int sum = 0; // sum the combination that satisfies given condition
            int biggestCombination = int.MinValue; // to store biggest combination
            int pos = 0;

            for(int i = 0; i < nList.Count - 1; i++)
            {
                pos = i;
                if (nList[i] == nList[i + 1]) //check combination of neighbor element 
                    sum += nList[i];
                else
                {
                    sum += nList[i]; //add the index value because it is equal to the recent last
                    if (sum > biggestCombination) // get biggestCombination so far
                        biggestCombination = sum;
                    // after getting the latest biggest combination reinitialize the sum 
                    // to get the next biggest combination if any
                    sum = 0; 
                }
            }

            // To check if the last index value is equal to the previous last index value
            // If they are equal then add the last index value with the sum
            // to get the biggest combination.
            if (nList[pos] == nList[pos + 1]) //pos + 1 == nList.Count - 1
            {
                sum += nList[pos + 1];
                if (sum > biggestCombination) // final adjustment, if last index value is equal to the previous last and added to sum
                    biggestCombination = sum;
            }
            else
            { //If they are not equal then put the last index value to sum;
              //because last index value can be individually the biggest.
                sum = nList[pos + 1];
                if (sum > biggestCombination) // final adjustment, if last index value is individually the greatest
                    biggestCombination = sum;
            }


            return biggestCombination;
        }
    }
}
