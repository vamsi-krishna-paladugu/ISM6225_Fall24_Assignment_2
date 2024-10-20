using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Linq;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                int n = nums.Length;
                bool[] seen = new bool[n + 1];
                IList<int> missingNumbers = new List<int>();

                // Mark numbers that are present in the array by setting the corresponding index in the 'seen' array to true.
                for (int i = 0; i < n; i++)
                {
                    if (nums[i] >= 1 && nums[i] <= n)
                    {
                        seen[nums[i]] = true;
                    }
                }

                // Loop through the range of numbers from 1 to n, adding missing numbers to the 'missingNumbers' list.
                for (int i = 1; i <= n; i++)
                {
                    if (!seen[i])
                    {
                        missingNumbers.Add(i);
                    }
                }

                // Return the list of missing numbers that were not found in the original array.
                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Write your code here
                int[] result = new int[nums.Length];
                int index = 0;

                // Iterate through the array and add all even numbers to the 'result' array in order.
                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        result[index++] = num;
                    }
                }

                // Iterate through the array again, this time adding all odd numbers to the 'result' array after the evens.
                foreach (int num in nums)
                {
                    if (num % 2 != 0)
                    {
                        result[index++] = num;
                    }
                }

                // Return the modified array where even numbers come first, followed by odd numbers.
                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                // Write your code here

                //Using dictionary/hash map to reduce the time complexity to O(n).
                Dictionary<int, int> valueIndexMap = new Dictionary<int, int>();

                // For each element in the array, check if its complement(target - current value) exists in the dictionary. 
                // If found, return the indices of the two numbers.
                for (int i = 0; i < nums.Length; i++)
                {
                    int requiredValue = target - nums[i];

                    if (valueIndexMap.ContainsKey(requiredValue))
                    {
                        return new int[] { valueIndexMap[requiredValue], i };
                    }

                    //If the complement is not found, store the current value and its index in the dictionary.
                    valueIndexMap[nums[i]] = i;
                }

                return new int[0]; // Return empty array if no solution is found
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Write your code here
                Array.Sort(nums);//sort in ascending order
                int n = nums.Length;
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3]; // Product of three largest
                int product2 = nums[0] * nums[1] * nums[n - 1]; // Product of two smallest and the largest
                return Math.Max(product1, product2); // Return maximum of the two products
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Write your code here
                if (decimalNumber == 0) return "0"; // edge case for 0 input
                string binaryResult = string.Empty;
                while (decimalNumber > 0)
                {
                    // concatenate the remainder to the binary result at front
                    binaryResult = (decimalNumber % 2) + binaryResult;
                    decimalNumber /= 2; // Divide the number by 2
                }

                return binaryResult; // Return the final binary string
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                int left = 0;
                int right = nums.Length - 1;
                // If the array has only one element and is not rotated, the first element is the smallest
                if (nums[left] < nums[right])
                {
                    return nums[left];
                }
                // Binary search for the minimum element
                while (left < right)
                {
                    int mid = left + (right - left) / 2;
                    // If the mid element is greater than the right element, the minimum is in the right half
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        // Otherwise, the minimum is in the left half (including mid)
                        right = mid;
                    }
                }

                // At the end of the loop, left == right, and it points to the minimum element
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Write your code here

                // Edge case: Negative numbers are not palindromes
                if (x < 0) return false;

                string rev = string.Empty;

                // Store the original value of x to compare later
                int orig  = x;

                // Loop to extract digits from x and build the reversed number
                while (x > 0)
                {
                    int rem = x % 10;
                    rev = rev + rem;
                    x = x / 10;
                }

                // Compare the original number with the reversed version (converted back to an integer)
                if (orig == int.Parse(rev))
                {
                    return true;
                }
                else {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Write your code here

                // Edge case for n = 0
                if (n == 0) return 0;

                // Edge case for n = 1
                if (n == 1) return 1;

                // Initialize the first two Fibonacci numbers
                int a = 0;
                int b = 1;

                // Variable to store the Fibonacci number
                int fib = 0;

                // Iterate from 2 to n, calculating the Fibonacci numbers
                for (int i = 2; i <= n; i++)
                {
                    fib = a + b; 
                    a = b;        
                    b = fib;      
                }

                return fib; // Return the Fibonacci number at position n
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
