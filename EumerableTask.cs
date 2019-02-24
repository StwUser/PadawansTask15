using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PadawansTask15
{
    public class EnumerableTask
    {
        /// <summary> Transforms all strings to upper case.</summary>
        /// <param name="data">Source string sequence.</param>
        /// <returns>
        ///   Returns sequence of source strings in uppercase.
        /// </returns>
        /// <example>
        ///    {"a", "b", "c"} => { "A", "B", "C" }
        ///    { "A", "B", "C" } => { "A", "B", "C" }
        ///    { "a", "A", "", null } => { "A", "A", "", null }
        /// </example>
        public IEnumerable<string> GetUppercaseStrings(IEnumerable<string> data)
        {
            List<string> newList = new List<string>();
            foreach (string st in data)
            {
                if (st == null)
                {
                    newList.Add(st);
                }
                else if ((st.Length > 0) && (st != st.ToUpper()))
                {
                    newList.Add(st.ToUpper());
                }
                else
                {
                    newList.Add(st);
                }
            }
            foreach (string st in newList)
                Console.WriteLine(st);
            return newList;
        }

        /// <summary> Transforms an each string from sequence to its length.</summary>
        /// <param name="data">Source strings sequence.</param>
        /// <returns>
        ///   Returns sequence of strings length.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   {"a", "aa", "aaa" } => { 1, 2, 3 }
        ///   {"aa", "bb", "cc", "", "  ", null } => { 2, 2, 2, 0, 2, 0 }
        /// </example>
        public IEnumerable<int> GetStringsLength(IEnumerable<string> data)
        {
            List<int> lenght = new List<int>();
            foreach (string st in data)
            {
                if (st == null)
                {
                    lenght.Add(0);
                }
                else
                {
                    lenght.Add((int)st.Length);
                }
            }
            return lenght;
        }

        /// <summary>Transforms integer sequence to its square sequence, f(x) = x * x. </summary>
        /// <param name="data">Source int sequence.</param>
        /// <returns>
        ///   Returns sequence of squared items.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2, 3, 4, 5 } => { 1, 4, 9, 16, 25 }
        ///   { -1, -2, -3, -4, -5 } => { 1, 4, 9, 16, 25 }
        /// </example>
        public IEnumerable<long> GetSquareSequence(IEnumerable<int> data)
        {
            List<long> squares = new List<long>();
            foreach (int n in data)
            {
                squares.Add(n * n);
            }
            return squares;
        }

        /// <summary> Filters a string sequence by a prefix value (case insensitive).</summary>
        /// <param name="data">Source string sequence.</param>
        /// <param name="prefix">Prefix value to filter.</param>
        /// <returns>
        ///  Returns items from data that started with required prefix (case insensitive).
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when prefix is null.</exception>
        /// <example>
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "b"  =>  { "bbbb" }
        ///  { "aaa", "bbbb", "ccc", null }, prefix = "B"  =>  { "bbbb" }
        ///  { "a","b","c" }, prefix = "D"  => { }
        ///  { "a","b","c" }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c", null }, prefix = ""   => { "a","b","c" }
        ///  { "a","b","c" }, prefix = null => ArgumentNullException
        /// </example>
        public IEnumerable<string> GetPrefixItems(IEnumerable<string> data, string prefix)
        {
            List<string> fields = new List<string>();
            if (prefix == null)
            {
                throw new ArgumentNullException();
            }
            if (prefix.Count() == 0)
            {
                foreach (string st in data)
                {
                    if ((st.Length > 0) || (st != null))
                    {
                        fields.Add(st);
                    }
                }
                return fields;
            }

            string s = @"^" + prefix.ToString() + "(\\w*)";
            Regex regex = new Regex(@"^"+prefix.ToString()+"(\\w*)", RegexOptions.IgnoreCase);

            foreach (string st in data)
            {
                MatchCollection matches = regex.Matches(st);
                if (matches.Count > 0)
                {
                        fields.Add(st);
                }
            }
            return fields;
        }

        /// <summary> Finds the 3 largest numbers from a sequence.</summary>
        /// <param name="data">Source sequence.</param>
        /// <returns>
        ///   Returns the 3 largest numbers from a sequence.
        /// </returns>
        /// <example>
        ///   { } => { }
        ///   { 1, 2 } => { 2, 1 }
        ///   { 1, 2, 3 } => { 3, 2, 1 }
        ///   { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 } => { 10, 9, 8 }
        ///   { 10, 10, 10, 10 } => { 10, 10, 10 }
        /// </example>
        public IEnumerable<int> Get3LargestItems(IEnumerable<int> data)
        {
            List<int> threeNumb = new List<int>();
            int valueMax=(int)data.First();
            if (data.Count() <= 3)
            {
                
                int[] arr = data.ToArray();
                Array.Sort(arr);
                Array.Reverse(arr);
                foreach (int i in arr)
                {
                    threeNumb.Add(i);
                }
                return threeNumb;
            }
            int[] arrayN = data.ToArray();
            Array.Sort(arrayN);
            Array.Reverse(arrayN);
            threeNumb.Add(arrayN[0]);
            threeNumb.Add(arrayN[1]);
            threeNumb.Add(arrayN[2]);
            return threeNumb;
        }

        /// <summary> Calculates sum of all integers from object array.</summary>
        /// <param name="data">Source array.</param>
        /// <returns>
        ///    Returns the sum of all integers from object array.
        /// </returns>
        /// <example>
        ///    { 1, true, "a", "b", false, 1 } => 2
        ///    { true, false } => 0
        ///    { 10, "ten", 10 } => 20 
        ///    { } => 0
        /// </example>
        public int GetSumOfAllIntegers(object[] data)
        {
            int index = 0;
            string[] varArr = new string[ data.Count()];
            foreach (var v in data)
            {
                varArr[index] = v.ToString();
                index++;
            }
            int sum = 0;
            foreach (var i in varArr)
            {
                int number;

                bool success = Int32.TryParse(i, out number);
                if (success)
                {
                    sum += number;
                }

            }
            return sum;
        }
    }
}