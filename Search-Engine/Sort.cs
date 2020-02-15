using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search_Engine
{
    public class Sort
    {
        public static void CountSort(string[] arr)
        {
            int arr_length = arr.Length;

            char[] new_arr = new char[arr_length];

            string[] output = new string[arr_length];

            int[] count = new int[256];

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
            // the character in output array 
            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

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

        public static void msdRadixSort(string[] arr)
        {
            msd(arr, 0, arr.Length, 0);
        }
        public static void msd(string[] arr, int low, int high, int alphInd)
        {
            if (high <= low + 1)
            {
                return;
            }

            int[] count = new int[256 + 1];
            string[] temp = new string[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                count[Convert.ToChar(arr[i].Substring(alphInd, 1)) + 1]++;
            }

            for (int i = 1; i < 256; i++)
            {
                count[i] += count[i - 1];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                temp[count[Convert.ToChar(arr[i].Substring(alphInd, 1))]++] = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = temp[i];
            }

            for (int i = 1; i < 255; i++)
            {
                msd(arr, low + count[i], low + count[i + 1], alphInd + 1);
            }
        }
        public static void quickSort(int[] arr, int low, int high, int ascending = 0)
        {
            if (low < high && ascending == 0)
            {
                int pi = partition(arr, low, high, 1);

                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
            else if (low < high && ascending != 0)
            {
                int pi = partition(arr, low, high, 1);
                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }
        public static int partition(int[] arr, int low, int high, int ascending)
        {
            int pivot = arr[high];

            int i = (low - 1);

            for (int j = high; j >= low; j--)
            {
                if (arr[j].CompareTo(pivot) == -1)
                {
                    i++;
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            int temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }


        public static void quickSort(string[] arr, int low, int high, int ascending = 0)
        {
            if (low < high)
            {
                int pi = partition(arr, low, high);

                quickSort(arr, low, pi - 1);
                quickSort(arr, pi + 1, high);
            }
        }

        public static int partition(string[] arr, int low, int high)
        {
            string pivot = arr[high];

            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                if (arr[j].CompareTo(pivot) == -1)
                {
                    i++;
                    string temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            string temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }

        public static int partition(string[] arr, int low, int high, int ascending)
        {
            string pivot = arr[high];

            int i = (low - 1);

            for (int j = high; j >= low; j--)
            {
                if (arr[j].CompareTo(pivot) == -1)
                {
                    i++;
                    string temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }

            string temp1 = arr[i + 1];
            arr[i + 1] = arr[high];
            arr[high] = temp1;

            return i + 1;
        }
    }
}
