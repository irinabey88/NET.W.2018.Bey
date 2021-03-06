﻿namespace ArraySort
{
    using System;
    using System.Collections.Generic;

    public class ArraySortDelegate
    {
        #region Public methods    

        /// <summary>
        /// Provides buble sort for <paramref name="jaggedArray"/> in 
        /// ascending/descending order bu given 
        /// </summary>
        /// <param name="jaggedArray">Input jaggedArray</param>
        /// <param name="comparer">Delegate comparator</param>
        /// <returns>Sorted jagged jaggedArray</returns>
        /// <exception cref="ArgumentNullException">Invalid input array</exception>
        /// <exception cref="ArgumentException">Invalid input array</exception>
        public static int[][] BubleSort(int[][] jaggedArray, Comparison<int[]> comparer)
        {
            if (jaggedArray == null || jaggedArray.Length == 0)
            {
                throw new ArgumentNullException(nameof(jaggedArray));
            }

            if (jaggedArray == null)
            {
                throw new ArgumentException(nameof(jaggedArray));
            }

            foreach (var inputArrays in jaggedArray)
            {
                if (inputArrays == null)
                {
                    throw new ArgumentNullException(nameof(inputArrays));
                }

                if (inputArrays.Length == 0)
                {
                    throw new ArgumentException(nameof(inputArrays));
                }
            }

            if (comparer == null)
            {
                throw new ArgumentNullException(nameof(comparer));
            }

            return BubleSortInterface(jaggedArray, new AdapterComparer(comparer));
        }
        #endregion

        #region Private methods


        private static int[][] BubleSortInterface(int[][] jaggedArray, IComparer<int[]> comparer)
        {
            var arrayLength = jaggedArray.GetLength(0);

            for (int j = arrayLength; j > 0; j--)
            {
                for (int i = 0; i < arrayLength - 1; i++)
                {
                    if (comparer.Compare(jaggedArray[i], jaggedArray[i + 1]) > 0)
                    {
                        Swap(ref jaggedArray[i], ref jaggedArray[i + 1]);
                    }
                }
            }

            return jaggedArray;
        }
        /// <summary>
        /// Change line-arrays in jagged array
        /// </summary>
        /// <param name="lhs">Left array</param>
        /// <param name="rhs">Right array</param>
        private static void Swap(ref int[] lhs, ref int[] rhs)
        {
            if (lhs == null)
            {
                throw new ArgumentNullException(nameof(lhs));
            }

            if (rhs == null)
            {
                throw new ArgumentNullException(nameof(rhs));
            }

            var temp = lhs;

            lhs = rhs;

            rhs = temp;
        }
        #endregion
    }
}