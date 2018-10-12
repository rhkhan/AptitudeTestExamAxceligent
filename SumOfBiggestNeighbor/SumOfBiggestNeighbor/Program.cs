//########
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
//##############

namespace AptitudeTest
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
                if (numberDictionary.ContainsKey(input[i]))
                {
                    nList.Add(input[i]);
                }
            }

            int sum = 0; // sum the combination that satisfies given condition
            int biggestCombination = int.MinValue; // to store biggest combination
            int pos = 0;

            for (int i = 0; i < nList.Count - 1; i++)
            {
                pos = i;
                if (nList[i] == nList[i + 1])
                    sum += nList[i];
                else
                {
                    sum += nList[i];
                    if (sum > biggestCombination)
                        biggestCombination = sum;
                    sum = 0;
                }
            }

            if (nList[pos] == nList[pos + 1] && pos + 1 == nList.Count - 1)
                sum += nList[pos + 1];

            if (sum > biggestCombination) // final adjustment
                biggestCombination = sum;

            return biggestCombination;
        }
    }
}
