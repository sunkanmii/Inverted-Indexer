using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Project
{
    public class CountingSort
    {
        public static void CountSort(string[] arr)
        {
            int arr_length = arr.Length;

            char[] new_arr = new char[arr_length];

            // The output character array that 
            // will have sorted arr. 
            string[] output = new string[arr_length];

            // Create a count array to store  
            // count of inidividual characters  
            // and initialize count array as 0 
            int[] count = new int[256];

            Console.WriteLine();
            for (int i = 0; i < 256; i++)
            {
                count[i] = 0;
            }

            // store count of each character 
            for (int i = 0; i < arr_length; i++)
            {
                new_arr[i] = Convert.ToChar(arr[i].Substring(0, 1));

                //Implicit type conversion from char to int
                //Possible in both C# and Java.
                ++count[new_arr[i]];
            }

            // Change count[i] so that count[i]  
            // now contains actual position of  
            // this character in output array 
            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            // Build the output character array 
            // To make it stable we are operating in reverse order. 
            for (int i = arr_length - 1; i >= 0; i--)
            {
                output[count[new_arr[i]] - 1] = arr[i];
                --count[new_arr[i]];
            }

            // Copy the output array to arr, so 
            // that arr now contains sorted  
            // characters 
            for (int i = 0; i < arr_length; i++)
            {
                arr[i] = output[i];
            }
        }
    }
}
