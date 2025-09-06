using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;

namespace Algorithms
{

    class HackerRank
    {
        public static int CountingValleys(int steps,string path)
        {
            int numberU = 0;
            int numberD = 0;
            int level;
            bool underSeaLevel = false;
            bool aboveSeaLevel = false;
            int numberOfValley = 0;
            int numberOfMountain = 0;
            for (int i = 0; i < steps; i++)
            {
                level = numberD - numberU;
                if (path[i] == 'D')
                {
                    numberD++;
                }
                if(path[i] == 'U')
                {
                    numberU++;
                }
                if(level == 0 && (numberD - numberU) < 0)//extra task
                {
                    aboveSeaLevel = true;
                }
                if(level == 0 && (numberD - numberU) > 0)
                {
                    underSeaLevel = true;
                }
                if(aboveSeaLevel && (numberD - numberU) == 0)//extra task
                {
                    numberOfMountain++;
                    aboveSeaLevel = false;
                    numberD = 0;
                    numberU = 0;
                    level = 0;
                }
                if(underSeaLevel && (numberD - numberU) == 0)
                {
                    numberOfValley++;
                    underSeaLevel = false;
                    numberD = 0;
                    numberU = 0;
                    level = 0;
                }
            }

            return numberOfValley;
        }

        public static List<int> CircularArrayRotation(List<int> a, int k, List<int> queries)
        {
            List<int> temp = new List<int>(new int[a.Count]);
            int size = a.Count;
            int newK = k % a.Count;
            if(newK < (a.Count/2) + 1)//rotate to right
            {
                for (int i = newK; i < size; i++)
                {
                    temp[i] = a[i - newK];
                }
                for (int i = 0; i < newK; i++)
                {
                    temp[i] = a[size - newK + i];
                }
                a.Clear();
                a.AddRange(temp);
            }
            else//rotate to left
            {
                for (int i = 0; i < size - newK; i++)
                {
                    temp[i] = a[i + newK];
                }
                for (int i = size - newK; i < size; i++)
                {
                    temp[i] = a[i - (size - newK)];
                }
                a.Clear();
                a.AddRange(temp);
            }

            List<int> result = new List<int>(new int[queries.Count]);
            for (int i = 0; i < queries.Count; i++)
            {
                result[i] = a[queries[i]];
            }

            return result;
        }

        public static string AppendAndDelete(string s, string t, int k)
        {
            int count = 0;
            if(s.Length > t.Length)
            {
                count += s.Length - t.Length;
                s = s.Substring(0, t.Length);
                for (int i = 0; i < t.Length; i++)
                {
                    if (s[i] != t[i])
                    {
                        count += s.Length - i;
                        count += t.Length - i;
                        break;
                    }
                }
            }
            else
            {
                count += t.Length - s.Length;
                t = t.Substring(0, s.Length);
                for (int i = 0; i < t.Length; i++)
                {
                    if (s[i] != t[i])
                    {
                        count += s.Length - i;
                        count += t.Length - i;
                        break;
                    }
                }
            }
            if (count > k)
            {
                return "No";
            }
            else
            {
                if (count == 0)
                {
                    if (k >= t.Length * 2 || k % 2 == 0)
                    {
                        return "Yes";
                    }
                }
                if (k >= s.Length + t.Length)
                {
                    return "Yes";
                }
                if ((k - count) % 2 == 0)
                {
                    return "Yes";
                }
                else
                {
                    return "No";
                }
            }
        }

        public static int DesignerPdfViewer(List<int> h, string word)
        {
            int maxHeight;
            int widht = word.Length;
            word = word.ToLower();
            List<int> heights = new List<int>(new int[word.Length]);
            for (int i = 0; i < word.Length; i++)
            {
                heights[i] = h[(int)word[i] - 97];
            }
            maxHeight = heights[0];
            for (int i = 0; i < heights.Count; i++)
            {
                if(maxHeight < heights[i])
                {
                    maxHeight = heights[i];
                }
            }
            return maxHeight * widht;
        }

        public static int UtopianTree(int n)
        {
            int height = 1;
            for (int i = 1; i <= n; i++)
            {
                if(i % 2 == 0)
                {
                    height += 1;
                }
                else
                {
                    height *= 2;
                }
            }
            return height;
        }

        public static int Lonelyinteger(List<int> a)
        {
            List<int> temp = new List<int>();
            temp.AddRange(a);
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = i + 1; j < a.Count; j++)
                {
                    if(a[i] == a[j])
                    {
                        temp.RemoveAll(x => x == a[i]);
                        break;
                    }
                } 
            }
            return temp[0];
        }

        public static int ViralAdvertising(int n)
        {
            int people = 5;
            int like = 0;
            int share;
            for (int i = 0; i < n; i++)
            {
                share = (people / 2) - ((people / 2) % 1);
                like += (people / 2) - ((people / 2) % 1);
                people = share * 3;
            }
            return like;
        }

        public static List<int> PermutationEquation(List<int> p)
        {
            List<int> result = new List<int>(new int[p.Count]);
            int index;
            for (int i = 0; i < p.Count; i++)
            {
                index = p.IndexOf(i + 1);
                result[i] = p.IndexOf(index);
            }
            return result;
        }

        public static int Camelcase(string s)
        {
            int number = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if((int)s[i] >=65 && (int)s[i] <=90)
                {
                    number++;
                }
            }
            return number + 1;
        }

        public static int EqualizeArray(List<int> arr)
        {
            List<int> numbers = new List<int>();
            int total = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if(arr[i] == arr[j])
                    {
                        total++;
                    }
                }
                numbers.Add(total + 1);
                total = 0;
            }
            int max = numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                if(max < numbers[i])
                {
                    max = numbers[i];
                }
            }

            return arr.Count - max;
        }

        public static int FindMedian(List<int> arr)
        {
            arr.Sort();

            return arr[(arr.Count-1)/2];
        }

        public static int SuperDigit(string n, int k)
        {
            long sum = 0;
            for (int i = 0; i < n.Length; i++)
            {
                sum = sum + Convert.ToInt32(n[i]) - 48;
            }
            sum *= k;
            string result = sum.ToString();
            if (result.Length == 1)
            {
                return Convert.ToInt32(result);
            }
            return SuperDigit(result, 1);
            
        }

        public static string BalancedSums(List<int> arr)
        {

            if(arr.Count == 1)
            {
                return "YES";
            }

            long sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            long left = 0, right = sum - arr[0];
            for (int i = 1; i < arr.Count; i++)
            {
                left += arr[i-1];
                right -= arr[i];
                if(left > right)
                {
                    return "NO";
                }
                if(left == right)
                {
                    return "YES";
                }
            }

            return "NO";
        }

        public static List<int> MissingNumbers(List<int> arr, List<int> brr)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < brr.Count; i++)
            {
                if (arr.Contains(brr[i]))
                {
                    arr.Remove(brr[i]);
                }
                else
                {
                    numbers.Add(brr[i]);
                }
            }


            //SECOND WAY 

            //bool isThere;
            //for (int i = 0; i < brr.Count; i++)
            //{
            //    isThere = false;
            //    if(numbers.Contains(brr[i]))
            //    {
            //        numbers.Add(brr[i]);
            //        continue;
            //    }
            //    for (int j = 0; j < arr.Count; j++)
            //    {
            //        if(brr[i] == arr[j])
            //        {
            //            arr[j] = 0;
            //            isThere = true;
            //            break;
            //        }
            //    }
            //    if(!isThere)
            //    {
            //        numbers.Add(brr[i]);
            //    }
            //}





            numbers.Sort();
            HashSet<int> temp = new HashSet<int>(numbers);
            numbers = new List<int>(temp);

            return numbers;
        }

        public static int StringConstruction(string s)
        {
            int[] letters = new int[26];
            int count = 0;

            for (int i = 0; i < letters.Length; i++)
            {
                letters[i] = 0;
            }

            for (int i = 0; i < s.Length; i++)
            {
                letters[(int)s[i] - 97]++;
            }

            foreach (var item in letters)
            {
                if(item != 0)
                {
                    count++;
                }
            }

            return count;
        }

        public static string TwoStrings(string s1, string s2)
        {
            s1 = s1.ToLower();
            s2 = s2.ToLower();
            for (int i = 0; i < 26; i++)
            {
                int temp = i + 97;
                if(s1.Contains((char)temp) && s2.Contains((char)temp))
                {
                    return "YES";
                }
            }
            return "NO";
        }

        public static int MakingAnagrams(string s1, string s2)
        {
            int[] letters1 = new int[26];
            int[] letters2 = new int[26];

            s1 = s1.ToLower();
            s2 = s2.ToLower();

            int total = 0;

            for (int i = 0; i < 26; i++)
            {
                letters1[i] = 0;
                letters2[i] = 0;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                letters1[(int)s1[i] - 97]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                letters2[(int)s2[i] - 97]++;
            }

            for (int i = 0; i < 26; i++)
            {
                total += Math.Abs(letters1[i] - letters2[i]);
            }

            return total;
        }

        public static int Anagram(string s)
        {
            if(s.Length % 2 != 0)
            {
                return -1;
            }

            string s1, s2;

            s1 = s.Substring(0, s.Length / 2);
            s2 = s.Substring(s.Length / 2);

            int[] letters1 = new int[26];
            int[] letters2 = new int[26];

            int total = 0;

            for (int i = 0; i < 26; i++)
            {
                letters1[i] = 0;
                letters2[i] = 0;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                letters1[(int)s1[i] - 97]++;
            }

            for (int i = 0; i < s2.Length; i++)
            {
                letters2[(int)s2[i] - 97]++;
            }

            for (int i = 0; i < 26; i++)
            {
                total += Math.Abs(letters1[i] - letters2[i]);
            }


            return total / 2;
        }

        public static string CesarCipher(string s, int k)
        {
            char[] c = s.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                
                if ( (int)(c[i]) >=97 && (int)(c[i]) <= 122 )
                {
                    k = k % 26;
                    int newLetter = (int)c[i] + k;
                    if (newLetter > 122)
                    {
                        newLetter = newLetter - 122;
                        c[i] = (char)(newLetter + 96);
                    }
                    else
                        c[i] = (char)newLetter;
                }
                if(( int)(c[i]) >= 65 && (int)(c[i]) <= 90)
                {
                    k = k % 26;
                    int newLetter = (int)c[i] + k;
                    if (newLetter > 90)
                    {
                        newLetter = newLetter - 90;
                        c[i] = (char)(newLetter + 64);
                    }
                    else
                        c[i] = (char)newLetter;
                }
            }
            string result = new string(c);
            return result;
        }

        public static int MarsExploration(string s)
        {
            int counter = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if((i - 1) % 3 == 0)
                {
                    if((char)s[i] != 'O')
                    {
                        counter++;
                    }
                }
                else
                {
                    if ((char)s[i] != 'S')
                    {
                        counter++;
                    }
                }
            }

            return counter;
        }

        public static long FibonacciModified(long t1, long t2, int n)
        {
            long number = 0;
            for (int i = 0; i < n - 2; i++)
            {
                number = t1 + t2 * t2;
                t1 = t2;
                t2 = number;
            }

            return number;
        }

        public static long FlippingBits(long n)
        {
            return 4294967295 - n;
        }

        public static string FunnyString(string s)
        {
            List<int> distances = new List<int>();

            for (int i = 0; i < s.Length - 1; i++)
            {
                distances.Add(Math.Abs((int)s[i] - (int)s[i + 1]));
            }
            if(distances.Count % 2 == 1)
            {
                for (int i = 0; i < distances.Count / 2; i++)
                {
                    if (distances[i] != distances[distances.Count - i - 1])
                    {
                        return "Not Funny";
                    }
                }
            }
            else
            {
                for (int i = 0; i < distances.Count + 1 / 2; i++)
                {
                    if (distances[i] != distances[distances.Count - i - 1])
                    {
                        return "NOT FUNNY";
                    }
                }
            }
            return "Funny";
        }

        public static int BeautifulBinaryString(string b)
        {
            int count = 0;
            char[] letters = b.ToCharArray();

            for (int i = 0; i < letters.Length - 2; i++)
            {
                if(letters[i] == '0' && letters[i + 1] == '1' && letters[i + 2] == '0' )
                {
                    if(i + 3 < letters.Length && letters[i + 3] == '1')
                    {
                        letters[i + 2] = '1';
                    }
                    else
                    {
                        letters[i + 1] = '0';
                    }
                    count++;
                }
            }

            return count;
        }

        public static int MinimumAbsoluteDifference(List<int> arr)
        {
            List<int> distances = new List<int>();
            arr.Sort();

            for (int i = 0; i < arr.Count - 1; i++)
            {
                distances.Add(Math.Abs(arr[i] - arr[i + 1]));
            }
            distances.Sort();
            return distances[0];
        }

        public static List<int> IcecreamParlor(int m, List<int> arr)
        {
            List<int> result = new List<int>();
            for (int i = 0; i < arr.Count; i++)
            {
                int money = m - arr[i];
                if(arr[i] >= m)
                {
                    continue;
                }
                for (int j = i + 1; j < arr.Count; j++)
                {
                    if(arr[j] == money)
                    {
                        result.Add(i + 1);
                        result.Add(j + 1);
                        result.Sort();
                        return result;
                    }
                }

            }
            return null;
        }

        public static string PermutingTwoArrays(int k, List<int> A, List<int> B)
        {
            A.Sort();
            B.Sort();

            for (int i = 0; i < A.Count; i++)
            {
                var result = A[i] + B[B.Count - i - 1];
                if(result < k)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        public static int MaximumToys(List<int> prices, int k)
        {
            int count = 0;
            int total = 0;
            prices.Sort();

            for (int i = 0; i < prices.Count; i++,count++)
            {
                total += prices[i];
                if(total > k)
                {
                    break;
                }
            }

            return count;
        }

        public static long MarcsCakewalk(List<int> calorie)
        {
            calorie.Sort();
            calorie.Reverse();
            long two = 1,sum = 0;

            for (int i = 0; i < calorie.Count; i++)
            {
                sum = sum + two * calorie[i];
                two = two * 2;
            }
            return sum;
        }

        public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int sum = 0;

            if(y2 > y1 || m2 > m1)
            {
                return 0;
            }


            if(y1 > y2)
            {
                return 10000;
            }
            if(m1 > m2)
            {
                sum = 500 * (m1 - m2);
                return sum;
            }
            if(d1 > d2)
            {
                sum = 15 * (d1 - d2);
                return sum;
            }

            return 0;
        }

        public static int Squares(int a, int b)
        {

            //THIS IS MATH

            int count = 0;
            int s = 0;
            List<int> numbers = new List<int>();
            for (int i = a;; i++)
            {
                if(Math.Sqrt(i) % 1 == 0)
                {
                    s++;
                    numbers.Add(i);
                }
                if(s == 2)
                {
                    break;
                }
            }

            int c = numbers[1] - numbers[0];
            int k = (c - 1) / 2;
            int temp = k * k;
            k--;
            for (int i = temp; i <= b; i = i + 2 * k + 1)
            {
                count++;
                k++;
            }

            return count;
        }

        public static long RepeatedString(string s, long n)
        {
            long result;
            long size = s.Length;
            long numberOfA = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                    numberOfA++;
            }
            long repeat = n / size;
            long k = n - (repeat * size);
            result = repeat * numberOfA;
            for (int i = 0; i < k; i++)
            {
                if(s[i] == 'a')
                {
                    result++;
                }
            }

            return result;
        }

        public static string SuperReducedString(string s)
        {
            var letter = s.ToCharArray();
            List<char> letters = new List<char>(letter);

            while(true)
            {
                bool check = false;
                for (int i = 0;; i++)
                {
                    if (i >= letters.Count - 1)
                        break;
                    if (letters[i] == letters[i + 1])
                    {
                        letters.RemoveAt(i);
                        letters.RemoveAt(i);
                        check = true;
                    }
                }

                if (!check)
                    break;
            }

            string result = "";

            foreach (var item in letters)
            {
                result += item;
            }
            if (result.Length == 0)
                return "Empty String";
            return result;
        }

        public static int FormingMagicSquare(List<List<int>> s)
        {
            List<List<int>> magicSquare1 = new List<List<int>>();
            magicSquare1.Add(new List<int>() { 8 ,3 ,4});
            magicSquare1.Add(new List<int>() { 1 ,5 ,9});
            magicSquare1.Add(new List<int>() { 6 ,7 ,2});

            List<List<int>> magicSquare2 = new List<List<int>>();
            magicSquare2.Add(new List<int>() { 4 ,9 ,2 });
            magicSquare2.Add(new List<int>() { 3 ,5 ,7 });
            magicSquare2.Add(new List<int>() { 8 ,1 ,6  });

            List<List<int>> magicSquare3 = new List<List<int>>();
            magicSquare3.Add(new List<int>() { 6 ,1 ,8 });
            magicSquare3.Add(new List<int>() { 7, 5, 3 });
            magicSquare3.Add(new List<int>() { 2, 9, 4 });

            List<List<int>> magicSquare4 = new List<List<int>>();
            magicSquare4.Add(new List<int>() { 2 ,7 ,6 });
            magicSquare4.Add(new List<int>() { 9 ,5 ,1 });
            magicSquare4.Add(new List<int>() { 4 ,3 ,8 });

            List<List<int>> magicSquare5 = new List<List<int>>();
            magicSquare5.Add(new List<int>() { 4, 3, 8 });
            magicSquare5.Add(new List<int>() { 9, 5, 1 });
            magicSquare5.Add(new List<int>() { 2, 7, 6 });

            List<List<int>> magicSquare6 = new List<List<int>>();
            magicSquare6.Add(new List<int>() { 6, 7, 2 });
            magicSquare6.Add(new List<int>() { 1, 5, 9 });
            magicSquare6.Add(new List<int>() { 8, 3, 4 });

            List<List<int>> magicSquare7 = new List<List<int>>();
            magicSquare7.Add(new List<int>() { 2, 9, 4 });
            magicSquare7.Add(new List<int>() { 7, 5, 3 });
            magicSquare7.Add(new List<int>() { 6, 1, 8 });

            List<List<int>> magicSquare8 = new List<List<int>>();
            magicSquare8.Add(new List<int>() { 8, 1, 6 });
            magicSquare8.Add(new List<int>() { 3, 5, 7 });
            magicSquare8.Add(new List<int>() { 4, 9, 2 });

            int result1 = 0;
            int result2 = 0;
            int result3 = 0;
            int result4 = 0;
            int result5 = 0;
            int result6 = 0;
            int result7 = 0;
            int result8 = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    result1 += Math.Abs(magicSquare1[i][j] - s[i][j]);
                    result2 += Math.Abs(magicSquare2[i][j] - s[i][j]);
                    result3 += Math.Abs(magicSquare3[i][j] - s[i][j]);
                    result4 += Math.Abs(magicSquare4[i][j] - s[i][j]);
                    result5 += Math.Abs(magicSquare5[i][j] - s[i][j]);
                    result6 += Math.Abs(magicSquare6[i][j] - s[i][j]);
                    result7 += Math.Abs(magicSquare7[i][j] - s[i][j]);
                    result8 += Math.Abs(magicSquare8[i][j] - s[i][j]);
                }
            }
            List<int> results = new List<int>() { result1, result2 ,result3 ,result4,result5,result6,result7,result8};

            int min = results[0];
            for (int i = 1; i < results.Count; i++)
            {
                if (min > results[i])
                    min = results[i];
            }

            return min;
        }

        public static string Encryption(string s)
        {
            s = s.Trim();
            if(s.Contains(' '))
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == ' ')
                    {
                        s = s.Remove(i, 1);
                        i--;
                    }
                }
            }
            int l =(int)Math.Sqrt(s.Length);

            int row = l;
            int column = l;
            if(row * column < s.Length)
            {
                column = l + 1;
                if(row * column < s.Length)
                {
                    row = l + 1;
                }
            }

            List<string> result = new List<string>();

            for (int i = 0; i < row; i++)
            {
                if(i == row - 1)
                {
                    result.Add(s.Substring(i * column, s.Length - i * column));
                    break;
                }
                result.Add(s.Substring(i*column, column));
            }

            int temp = column - result[result.Count - 1].Length;

            for (int i = 0; i < temp; i++)
            {
                result[result.Count - 1] += "1";
            }

            string last = "";

            for (int i = 0; i < column; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    last += result[j][i];
                }
                last += " ";
            }
            if (last.Contains('1'))
            {
                for (int i = 0; i < last.Length; i++)
                {
                    if (last[i] == '1')
                    {
                        last = last.Remove(i, 1);
                        i--;
                    }
                }
            }

            return last;
        }

        public static int MinimumDistances(List<int> a)
        {
            List<int> distances = new List<int>();
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = i + 1; j < a.Count; j++)
                {
                    if(a[i] == a[j])
                    {
                        distances.Add(Math.Abs(i - j));
                        a.RemoveAt(j);
                        i--;
                        j--;
                    }
                }
            }

            distances.Sort();
            return distances.Count == 0 ? -1 : distances[0];
        }

        public static string IsValid(string s)
        {
            List<int> numbersOfLetters = new List<int>();
            for (int i = 0; i < 26; i++)
            {
                numbersOfLetters.Add(0);
            }

            for (int i = 0; i < s.Length; i++)
            {
                numbersOfLetters[(int)s[i] - 97]++;
            }

            numbersOfLetters.RemoveAll(x => x == 0);
            numbersOfLetters.Sort();
            int min = numbersOfLetters[0];

            if(min == 1)
            {
                int temp = numbersOfLetters[1] - min;
                bool chechk = false;
                for (int i = 2; i < numbersOfLetters.Count; i++)
                {
                    if(numbersOfLetters[i] - min != temp)
                    {
                        chechk = true;
                        break;
                    }
                }
                if(!chechk)
                {
                    return "YES";
                }
            }

            for (int i = 0; i < numbersOfLetters.Count; i++)
            {
                numbersOfLetters[i] = numbersOfLetters[i] - min;
            }

            int count = 0;

            for (int i = 0; i < numbersOfLetters.Count; i++)
            {
                if(numbersOfLetters[i] != 0)
                {
                    count++;
                }
                if(count == 2 || numbersOfLetters[i] > 1)
                {
                    return "NO";
                }
            }
            return "YES";
        }

        public static long TaumBday(long b, long w, long bc, long wc, long z)
        {
            long result;

           if(bc < wc)
           {
                if(bc + z < wc)
                {
                    result = (bc * (b + w)) + w * z;
                }
                else
                {
                    result = (bc * b) + (wc * w);
                }
           }
           else
           {
                if(wc + z < bc)
                {
                    result = (wc * (b + w)) + b * z;
                }
                else
                {
                    result = (bc * b) + (wc * w);
                }
           }

            return result;
        }

        public static int MaxMin(int k, List<int> arr)
        {
            List<int> distances = new List<int>();
            arr.Sort();
            if (k == arr.Count)
                return arr[arr.Count - 1] - arr[0];
            for (int i = 0; i < arr.Count - k; i++)
            {
                distances.Add(Math.Abs(arr[i] - arr[i + k - 1]));
            }
            distances.Sort();

            return distances[0];
        }

        public static int GetTotalX(List<int> a, List<int> b)
        {
            List<int> numbers = new List<int>();
            a.Sort();
            b.Sort();

            for (int i = 1; i <= b[0]; i++)
            {
                bool chechk = false;
                bool chechk2 = false;
                for (int j = 0; j < a.Count; j++)
                {
                    if(i % a[j] != 0)
                    {
                        chechk = true;
                        break;
                    }
                }
                if(chechk)
                {
                    continue;
                }
                for (int k = 0; k < b.Count; k++)
                {
                    if(b[k] % i != 0)
                    {
                        chechk2 = true;
                        break;
                    }
                }
                if(!chechk2)
                {
                    numbers.Add(i);
                }
            }
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
            return numbers.Count;
        }

        public static List<int> ClimbingLeaderboard(List<int> ranked, List<int> player)//Zamana takıldı.
        {
            List<int> ranks = new List<int>();
            int totalPoint;
            HashSet<int> temp = new HashSet<int>(ranked);
            ranked = new List<int>(temp);
            ranked.Sort();

            for (int i = 0; i < player.Count; i++)
            {
                totalPoint = player[i];
                if(ranked.Contains(totalPoint))
                {
                    ranks.Add(ranked.Count - ranked.IndexOf(totalPoint));
                    continue;
                }

                for (int j = 0; j < ranked.Count; j++)
                {
                    if (totalPoint < ranked[j])
                    {
                        ranks.Add(ranked.Count - j + 1);
                        break;
                    }
                    if (j == ranked.Count - 1)
                    {
                        ranks.Add(1);
                    }
                }
            }
            foreach (var item in ranks)
            {
                Console.WriteLine(item);
            }
            return ranks;


            //List<int> ranks = new List<int>();
            //int totalPoint = 0;
            //HashSet<int> temp = new HashSet<int>(ranked);
            //ranked = new List<int>(temp);
            //ranked.Sort();
            //ranked.Reverse();

            //for (int i = 0; i < player.Count; i++)
            //{
            //    totalPoint = player[i];
            //    if (ranked.Contains(totalPoint))
            //    {
            //        ranks.Add(ranked.IndexOf(totalPoint) + 1);
            //        continue;
            //    }
            //    ranked.Add(totalPoint);
            //    ranked.Sort();
            //    ranked.Reverse();
            //    ranks.Add(ranked.IndexOf(totalPoint) + 1);
            //    ranked.Remove(totalPoint);
            //}
            //return ranks;

        }

        public static string CountLuck(List<string> matrix, int k)
        {
            //int count = 0;

            while (true)
            {
                char left, right, up, down;

                int[] position = new int[2];
                int[] target = new int[2];
                bool chechk1=false,check2 = false;

                for (int i = 0; i < matrix.Count; i++)
                {
                    if(matrix[i].Contains('*'))
                    {
                        position[0] = i;
                        position[1] = matrix[i].IndexOf('*');
                        chechk1 = true;

                    }
                    if(matrix[i].Contains('M'))
                    {
                        target[0] = i;
                        target[1] = matrix[i].IndexOf('M');
                        check2 = true;
                    }
                    if (chechk1 && check2)
                        break;
                }

                if(position[1] > 1)
                {
                    left = matrix[position[0]][position[1] - 1];
                }
                if(position[1] < matrix[0].Length - 1)
                {
                    right = matrix[position[0]][position[1] + 1];
                }

                if (position[0] > 1)
                {
                    up = matrix[position[0] - 1][position[1]];
                }
                if (position[0] < matrix.Count - 1)
                {
                    down = matrix[position[0] + 1][position[1] + 1];
                }
                break;
            }

            return "";
        }

        public static string GameOfThrones(string s)
        {
            List<int> numberOfLetters = Enumerable.Repeat(0,26).ToList();
            for (int i = 0; i < s.Length; i++)
            {
                numberOfLetters[(int)s[i] - 97]++;
            }
            int count = 0;
            foreach (var item in numberOfLetters)
            {
                if(item % 2 != 0)
                {
                    count++;
                }
            }
            if(count == 1 && s.Length % 2 != 0)
            {
                return "YES";
            }
            if(count > 1)
            {
                return "NO";
            }
            return "YES";
        }

        public static int TheLoveLetterMystery(string s)
        {
            int count = 0;
            for (int i = 0; i < s.Length/2; i++)
            {
                count = count + Math.Abs((int)s[i] - (int)s[s.Length - i - 1]);
            }

            return count;
        }

        public static int Gemstones(List<string> arr)
        {
            int count = 0;
            bool check;
            for (int i = 0; i < 26; i++)
            {
                check = false;
                for (int j = 0; j < arr.Count; j++)
                {
                    if (!arr[j].Contains((char)(i + 97)))
                    {
                        check = true;
                        break;
                    }
                }
                if(!check)
                {
                    count++;
                }
            }

            return count;
        }

        public static List<int> GetMax(List<string> operations)
        {
            List<int> result = new List<int>();
            List<int> stack = new List<int>();

            foreach (var operation in operations)
            {
                if (operation[0] == '1')
                {
                    stack.Add(Convert.ToInt32(operation.Substring(1)));
                }
                else if (operation[0] == '2')
                {
                    stack.RemoveAt(stack.Count - 1);
                }
                else
                {
                    result.Add(stack.Max());
                }
            }

            return result;
        }

        public static List<int> ClosestNumbers(List<int> arr)
        {
            List<int> result = new List<int>();

            arr.Sort();
            int minDistance = Math.Abs(arr[0] - arr[1]);
            result.Add(arr[0]);
            result.Add(arr[1]);
            for (int i = 1; i < arr.Count - 1; i++)
            {
                int distance = Math.Abs(arr[i] - arr[i + 1]);
                if(distance < minDistance)
                {
                    minDistance = distance;
                    result.Clear();
                }
                if(distance == minDistance)
                {
                    result.Add(arr[i]);
                    result.Add(arr[i + 1]);
                }
            }

            return result;
        }

        public static int JumpingOnClouds(int[] c, int k)
        {
            int energy = 100;
            int index = 0;
            while (true)
            {
                index = index + k;
                index = index % c.Length;
                energy--;
                if (c[index] == 1)
                {
                    energy -= 2;
                }

                if(index == 0)
                {
                    break;
                }
            }

            return energy;
        }

        public static int SherlockAndAnagrams(string s)
        {
            int count = 0;
            List<int> subString1 = Enumerable.Repeat(0, 26).ToList();
            List<int> subString2 = Enumerable.Repeat(0, 26).ToList();
            for (int i = 1; i < s.Length; i++)//size of substring
            {
                for (int j = 0; j < s.Length - i + 1; j++)
                {
                    string str1 = s.Substring(j, i);
                    for (int a = 0; a < str1.Length; a++)
                    {
                        subString1[(int)str1[a]-97]++;
                    }

                    for (int k = j + 1; k < s.Length - i + 1; k++)
                    {
                        string str2 = s.Substring(k, i);
                        for (int a = 0; a < str2.Length; a++)
                        {
                            subString2[(int)str2[a]-97]++;
                        }
                        if(subString1.SequenceEqual(subString2))
                        {
                            count++;
                        }
                        subString2 = Enumerable.Repeat(0, 26).ToList();
                    }
                    subString1 = Enumerable.Repeat(0, 26).ToList();
                }
            }


            return count;
        }

        public static int SaveThePrisoner(int n, int m, int s)
        {
            int number = m % n;
            var result = (s + number - 1) % (n+1);
            return result;
        }

        public static List<int> CutTheSticks(List<int> arr)
        {
            var stickCount = new List<int>();

            do
            {
                stickCount.Add(arr.Count);

                var min = arr.Min();

                arr.RemoveAll(x => x == min);

            } while (arr.Count != 0);

            return stickCount;
        }

        public static void KaprekarNumbers(int p, int q)
        {
            var response = new List<long>();

            if(p == 1)
            {
                response.Add(1);
            }

            for (long i = p; i <= q; i++)
            {
                var square = (i * i).ToString();
                
                var length = square.Length;

                if(length == 1)
                {
                    continue;
                }

                var number1 = int.Parse(square.Substring(0, length / 2));
                var number2 = int.Parse(square.Substring(length / 2));

                if (number1 + number2 == i && number2 != 0)
                {
                    response.Add(i);
                }
            }

            if(response.Count != 0)
            {
                foreach (var item in response)
                {
                    Console.WriteLine(item.ToString() + " ");
                }
            }
            else
            {
                Console.WriteLine("INVALID RANGE");
            }
        }

        public static int PalindromeIndex(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != s[s.Length - i - 1])
                {
                    if (s[i] == s[s.Length - i - 2])
                    {
                        return s.Length - i - 1;
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            return -1;
        }

        public static int MaximizingXor(int l, int r)
        {
            var max = 0;
            for (int i = l; i <= r; i++)
            {
                for(int j = l; j <= r; j++)
                {
                    var value = i ^ j;

                    if (value > max)
                    {
                        max = value;
                    }
                }
            }

            return max;
        }

        public static string FairRations(List<int> breads)
        {
            var oddCount = breads.Count(x => x % 2 == 1);

            if(oddCount % 2 == 1)
            {
                return "NO";
            }

            var count = 0;

            for (int i = 0; i < breads.Count - 1; i++)
            {
                if (breads[i] % 2 == 1)
                {
                    breads[i]++;
                    breads[i + 1]++;
                    count += 2;
                }
            }

            return count.ToString();
        }

        public static List<int> QuickSort(List<int> arr)
        {
            var left = new List<int>();
            var right = new List<int>();
            var equel = arr[0];

            foreach(var item in arr)
            {
                if(item < equel)
                {
                    left.Add(item);
                }
                if(item > equel)
                {
                    right.Add(item);
                }
            }

            var result = new List<int>();

            result.AddRange(left);
            result.Add(equel);
            result.AddRange(right);

            return result;
        }

        public static void InsertionSort2(int n, List<int> arr)
        {
            for(int i = 0; i < arr.Count;i++)
            {
                for(int j = i + 1; j < arr.Count; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        var temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }

                Console.WriteLine(string.Join(' ', arr));
            }
        }

        public static void ExtraLongFactorials(int n)
        {
            BigInteger sum = 1;
            for (var i = 1; i <= n; i++)
            {   
                sum *= i;
            }

            Console.WriteLine(sum);
        }

        public static bool IsSmartNumber(int num)
        {
            int val = (int)Math.Sqrt(num);
            if (num % val == 0 && num % 2 != 0)
                return true;
            return false;
        }

        public static long SumXor(long n)
        {
            var count = 0;
            int bitLength = (int)Math.Floor(Math.Log2(n)) + 1;

            var mask = (1L << bitLength) - 1;
            var result = (~n) & mask;
            for (int i = 0; i <= n; i++)
            {
                if ((n + i) == (n ^ i))
                {
                    count++;
                }
                if (i > result)
                {
                    break;
                }
            }
            return count;
        }

        public static int jumpingOnClouds(List<int> c)
        {
            var count = 0;
            for (int i = 0; i < c.Count - 1;)
            {
                if (i + 2 < c.Count && c[i+2] == 0)
                {
                    i += 2;
                }
                else if(c[i+1] == 0)
                {
                    i++;
                }
                count++;
            }

            return count;
        }

        public static List<int> serviceLane(List<List<int>> cases, List<int> width)
        {
            var result = new List<int>();
            for (int i = 0; i < cases.Count; i++)
            {
                var index1 = cases[i][0];
                var index2 = cases[i][1];

                result.Add(width.GetRange(index1, index2 - index1 + 1).Min());
            }

            return result;
        }

    }

    public static class StringExtensions
    {
        public static string Capitalize(this string value)
        {
            return string.Concat(value.Substring(0, 1).ToUpper(), value.Remove(0, 1));
        }
    }

    public static class Normalizer
    {
        public static string Normalize(this string s, string languageCode = "")
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            if (!string.IsNullOrEmpty(languageCode))
            {
                culture = CultureInfo.CreateSpecificCulture(languageCode);
            }

            Regex rgx = new Regex(@"[^\p{L}\p{N}#\+\.]");
            string filtered = rgx.Replace(s, "");
            return filtered.ToUpper(culture);
        }
    }

    class DataTypes
    {
        public static List<int> ReverseArray(List<int> a)
        {
            for (int i = 0; i < a.Count / 2; i++)
            {
                int temp = a[i];
                a[i] = a[a.Count - i - 1];
                a[a.Count - i - 1] = temp;
            }

            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var result = HackerRank.jumpingOnClouds(new List<int> { 0,1,0,0,0,1,0});
            Console.WriteLine(result);
            
            Console.ReadLine();
        }
       
    }
}
