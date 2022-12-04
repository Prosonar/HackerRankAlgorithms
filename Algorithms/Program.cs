using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

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
            #region
            //List<string> test = new List<string>()
            //{
            //    "352926151 380324688 94730870",
            // "94431605 679262176 5284458" ,
            // "208526924 756265725 150817879" ,
            // "962975336 972576181 396355184" ,
            // "464237185 937820284 255816794" ,
            // "649320641 742902564 647542323" ,
            // "174512033 711706897 68977959" ,
            // "107283902 156676511 67149447" ,
            // "104513201 298399273 96292548" ,
            // "113378824 274011418 98103763" ,
            // "934815799 991959468 212396037 " ,
            // "88325121 435452998 24617705   " ,
            // "984873585 997634055 103050157 " ,
            // "344218387 715364875 90658180  " ,
            // "556065259 615709967 156417592 " ,
            // "57109959 451440582 4188603    " ,
            // "353972922 573651462 244520504 " ,
            // "946486979 973168361 647886035 " ,
            // "368127406 680428368 105517295 " ,
            // "884634320 965112925 119757238 " ,
            // "422557970 744431033 28932300  " ,
            // "634954007 957414623 341366379 " ,
            // "190265362 445253893 184632922 " ,
            // "293315518 479153471 120684020 " ,
            // "72410472 80198999 984948      " ,
            // "784893322 849791807 360911386 " ,
            // "846191883 880790237 510053756 " ,
            // "297201660 812278057 198376746 " ,
            // "945087694 999220046 465061514 " ,
            // "786859800 831171414 378370933 " ,
            // "528402029 859318899 224559950 " ,
            // "522640531 755821672 28838424  " ,
            // "864006909 879474138 806467486 " ,
            // "613544440 943850900 258190755 " ,
            // "734228459 928771704 265979283 " ,
            // "542812502 597832172 330877768 " ,
            // "541133561 748691081 126348492 " ,
            // "51187317 524866691 1143193    " ,
            // "885290374 990676850 373368385 " ,
            // "147955933 450823700 138416059 " ,
            // "100046465 587967212 32555061  " ,
            // "233926824 996957988 31809378  " ,
            // "785405778 835771758 689182705 " ,
            // "444389615 870657324 72775880  " ,
            // "702580369 895325888 345053199 " ,
            // "968559651 974760313 326732084 " ,
            // "299437419 514618345 254272806 " ,
            // "901702945 930227426 727030891 " ,
            // "721843209 736359383 225283784 " ,
            // "833018320 883439261 806599246 " ,
            // "267346244 307857609 46989880  " ,
            // "299901304 892163356 210218436 " ,
            // "565637506 795821687 158300457 " ,
            // "107336562 781910357 54488503  " ,
            // "513281286 916998022 254269425 " ,
            // "413431205 611661371 188998419 " ,
            // "740163288 938647312 571382392 " ,
            // "44702121 296589002 43470596   " ,
            // "771733011 919327188 317638907 " ,
            // "718860003 815844769 495144331 " ,
            // "377975600 438513404 111085209 " ,
            // "424965480 928959619 20776133  " ,
            // "234986523 732169039 205952749 " ,
            // "377078343 981597420 219264561 " ,
            // "612269027 791414524 580170106 " ,
            // "232336090 616084008 81392003  " ,
            // "75059328 274029861 53524881   " ,
            // "239121359 646856043 141349731 " ,
            // "923193147 943368157 206717532 " ,
            // "12565064 536852817 11557940   " ,
            // "360225746 970375527 284883902 " ,
            // "213705306 380885426 14495860  " ,
            // "659446919 699401237 73837176  " ,
            // "335372713 785363124 7610828   " ,
            // "538388654 859196325 110284314 " ,
            // "118558760 713483972 83950807  " ,
            // "896959032 961368580 8848444   " ,
            // "25543240 521123082 2472730    " ,
            // "258530682 935834352 194732411 " ,
            // "465248213 679599042 334563499 " ,
            // "331230504 637771661 76778140  " ,
            // "976340152 988657462 243958260 " ,
            // "552994811 922743535 540135280 " ,
            // "626831986 839281366 24222267  " ,
            // "157704591 253731033 59023773  " ,
            // "806377559 859228114 238044289 " ,
            // "838798445 996851254 268459446 " ,
            // "847646888 928001503 755190846 " ,
            // "877625009 999275937 874127074 " ,
            // "847949466 893343194 10497830  " ,
            // "35029316 784675240 8200127    " ,
            // "111807455 690309882 23190325  " ,
            // "355765714 554560093 311565654 " ,
            // "1890615 614626804 976253      " ,
            // "132293206 165429783 65360680  " ,
            // "506726160 934170235 455394293 " ,
            // "210041918 328800789 159203369 " ,
            // "499999999 999999997 2         " ,
            // "499999999 999999998 2         " ,
            // "999999999 999999999 1"
            //                };
            //var results = new List<int>()
            //{
            //    122129406
            //    ,23525398
            //    ,72975907
            //    ,405956028
            //    ,265162707
            //    ,91803604
            //    ,82636723
            //    ,9258153
            //    ,81152217
            //    ,31978708
            //    ,269539705
            //    ,18445097
            //    ,115810626
            //    ,117586280
            //    ,216062299
            //    ,55859471
            //    ,110226121
            //    ,674567416
            //    ,49690850
            //    ,200235842
            //    ,350805362
            //    ,28872987
            //    ,59090728
            //    ,13206454
            //    ,8773474
            //    ,425809870
            //    ,544652109
            //    ,119049822
            //    ,519193865
            //    ,422682546
            //    ,27074790
            //    ,262019564
            //    ,821934714
            //    ,588497214
            //    ,460522527
            //    ,385897437
            //    ,333906011
            //    ,14136713
            //    ,478754860
            //    ,145371959
            //    ,20243482
            //    ,93060069
            //    ,739548684
            //    ,54653973
            //    ,537798717
            //    ,332932745
            //    ,170016312
            //    ,755555371
            //    ,239799957
            //    ,24001866
            //    ,87501244
            //    ,202677879
            //    ,388484637
            //    ,85042925
            //    ,144704874
            //    ,387228584
            //    ,29703127
            //    ,27144750
            //    ,465233083
            //    ,592129096
            //    ,171623012
            //    ,99804791
            //    ,233162218
            //    ,69626951
            //    ,147046575
            //    ,467740
            //    ,27317429
            //    ,70841696
            //    ,226892541
            //    ,8113004
            //    ,174582190
            //    ,181675979
            //    ,113791493
            //    ,122228525
            //    ,431091984
            //    ,86082218
            //    ,73257991
            //    ,12731011
            //    ,96444034
            //    ,83666114
            //    ,52088792
            //    ,256275569
            //    ,356889192
            //    ,236671646
            //    ,155050214
            //    ,290894843
            //    ,426512254
            //    ,835545460
            //    ,118152992
            //    ,55891557
            //    ,22230414
            //    ,42655476
            //    ,154594318
            //    ,1153181
            //    ,98497256
            //    ,376112207
            //    ,67920321
            //    ,499999999
            //    ,1
            //    ,999999999
            //};
            //int count = 0;
            //foreach (var item in test)
            //{
            //    var temp = item.TrimEnd().Split(' ').ToList();
            //    var result = HackerRank.SaveThePrisoner(Convert.ToInt32(temp[0]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[2]));
            //    if (results[count] != result)
            //    {
            //        Console.WriteLine("******************Hata************************");
            //    }
            //    Console.WriteLine(result);
            //    count++;
            //}

            #endregion
            var result = HackerRank.SaveThePrisoner(208526924, 756265725, 150817879);
            Console.WriteLine(result);
            Console.ReadLine();
        }
        
        void PIWorksTest()
        {
        int[] numbers =
        {
                215,
                193, 124,
                117, 237, 442,
                218, 935, 347, 235,
                320, 804, 522, 417, 345,
                229, 601, 723, 835, 133, 124,
                248, 202, 277, 433, 207, 263, 257,
                359, 464, 504, 528, 516, 716, 871, 182,


            };
        int[] a = { 1, 8, 4, 2, 6, 9, 8, 5, 9, 3 };
        int result = PIWorks.FindPathWithMaxValue(numbers);
        bool isPrime = PIWorks.IsPrimeNumber(541);
        Console.WriteLine(result);
    }
    }
}
