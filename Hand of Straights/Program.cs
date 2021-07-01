using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hand_of_Straights
{
    class Program
    {
        static void Main(string[] args)
        {
            var hand = new int[] { 1, 2, 3, 6, 2, 3, 4, 7, 8 };
            Console.WriteLine(IsNStraightHand(hand, 3));
        }

        static bool IsNStraightHand(int[] hand, int groupSize)
        {
            // check grouping possible or not ?
            if (hand.Length % groupSize != 0) return false;

            // create dictioanry for the array input, count the frequency
            SortedDictionary<int, int> kvp = new SortedDictionary<int, int>();
            foreach (int i in hand)
                if (kvp.ContainsKey(i))
                    kvp[i] += 1;
                else
                    kvp.Add(i, 1);

            //
            while (kvp.Count > 0)
            {
                // take the min no as the starting, 
                int minKey = kvp.Keys.First();
                // loop through for groupsize and increment by one
                for (int i = minKey; i < minKey + groupSize; i++)
                {
                    // return false if consiqutive element is missing
                    if (!kvp.ContainsKey(i)) return false;
                    int count = kvp[i];
                    // when only one elemenet is present use it and remove it.
                    if (count == 1) kvp.Remove(i);
                    kvp[i] -= 1;
                }
            }

            return true;
        }
    }
}
