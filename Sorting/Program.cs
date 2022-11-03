using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {

        static void BubbleSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 0; i < array.Length-1; i++)
            {
                for (int j = 0; j < n- i -1; j++)
                {
                    comparisons++;
                    if (array[j] > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        assignments += 2;
                    }
                }
            }
            Console.WriteLine($"A: {assignments} | C: {comparisons} | C+A: {comparisons + assignments}");
        }

        static void SelectionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    comparisons++;
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                Swap(ref array[i], ref array[min]);
                assignments += 2;
            }
            Console.WriteLine($"A: {assignments} | C: {comparisons} | C+A: {comparisons + assignments}");
        }

        static void InsertionSort(int[] array)
        {
            int comparisons = 0;
            int assignments = 0;
            int n = array.Length;
            for (int i = 1; i <= n - 1; i++)
            {
                int temp = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > temp)
                {
                    comparisons++;
                    array[j + 1] = array[j];
                    assignments++;
                    j--;
                }
                array[j + 1] = temp;
                assignments++;
            }
            Console.WriteLine($"A: {assignments} | C: {comparisons} | C+A: {comparisons + assignments}");
        }

        static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        static void MergeSort(int[] array)
        {
            int length_of_array = array.Count();
            if (length_of_array > 2)
            {
                int mid_index = length_of_array / 2;
                
                int[] left_array = new int[mid_index];
                Array.Copy(array, left_array, mid_index);
                int[] right_array = new int[length_of_array - mid_index];
                Array.Copy(array, mid_index, right_array, 0, length_of_array - mid_index);

                MergeSort(left_array);
                MergeSort(right_array);

                Merge(left_array, right_array);
            }
        }

        static void Merge(int[] left_array, int[] right_array)
        {
            int[] merged_array = new int[left_array.Count() + right_array.Count()];
            int left_index = 0;
            int right_index = 0;
            int merged_index = 0;

            while (left_index < left_array.Count() && right_index < right_array.Count())
            {
                if (left_array[left_index] < right_array[right_index])
                {
                    merged_array[merged_index] = left_array[left_index];
                    left_index++;
                }
                else
                {
                    merged_array[merged_index] = right_array[right_index];
                    right_index++;
                }
                merged_index++;
            }

            while (left_index < left_array.Count())
            {
                merged_array[merged_index] = left_array[left_index];
                left_index++;
                merged_index++;
            }

            while (right_index < right_array.Count())
            {
                merged_array[merged_index] = right_array[right_index];
                right_index++;
                merged_index++;
            }

        }


        private static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[] array = new int[size];
            Random random = new Random();
            // Fill with random numbers between 0 and 99
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(30);
            }

            // Reverse
            /*            for (int i = 0; i < array.Length; i++)
                        {
                            array[i] = array.Length - i;
                        }*/

            // Sorted
            /*for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }*/


            int[] array2 = (int[]) array.Clone();
            int[] array3 = (int[]) array.Clone();
            int[] array4 = (int[]) array.Clone();

            Print(array);
            Console.WriteLine("Bubble Sort: ");
            BubbleSort(array);
            Print(array);
            Console.WriteLine("Selection Sort: ");
            SelectionSort(array2);
            Print(array2);
            Console.WriteLine("Insertion Sort: ");
            InsertionSort(array3);
            Print(array3);
            Console.WriteLine("Merge Sort: ");
            MergeSort(array4);
            Print(array4);

            Console.ReadLine();
        }


    }
}
