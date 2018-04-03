﻿// <copyright file="ArraySortTests.cs" company="Iryna Bey">
// Copyright (c) Iryna Bey. All rights reserved.
// </copyright>
namespace NET.W._2018.Bey._04.Tests.NUnitTests
{
    using System;
    using Comparers;
    using NUnit.Framework;
    using Services;

    /// <summary>
    /// Provides test for class ArraySort
    /// </summary>
    [TestFixture]
    public class ArraySortTests
    {
        [Test]      
        public void ArraySort_ValidData_SumDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 } };

            CollectionAssert.AreEqual(arr1.BubleSort(new SumElementComparer(), false), resultArr1); 
        }

        [Test]
        public void ArraySort_ValidData_SumAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 1, -2, 7, -4 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(arr1.BubleSort(new SumElementComparer()), resultArr1);
        }

        [Test]      
        public void ArraySort_ValidData_MinDescending_Test()
        {         
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 } };

            CollectionAssert.AreEqual(arr1.BubleSort(new MinElementComparer(), false), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MinAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(arr1.BubleSort(new MinElementComparer()), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxDescending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };

            CollectionAssert.AreEqual(arr1.BubleSort(new MaxElementComparer(), false), resultArr1);
        }

        [Test]
        public void ArraySort_ValidData_MaxAscending_Test()
        {
            int[][] arr1 = { new[] { 1, -2, 7, -4 }, new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 } };
            int[][] resultArr1 = { new[] { 5, -2, -4, -3 }, new[] { 2, 5, -3 }, new[] { 1, -2, 7, -4 } };          

            CollectionAssert.AreEqual(resultArr1, arr1.BubleSort(new MaxElementComparer(), true));            
        }

        /// <summary>
        /// Test for bublesort
        /// </summary>
        /// <param name="arg1">Input jagged array</param>
        [TestCase(null)]
        public void ArraySort_InvalidData_Test(int[][] arg1)
        {
            Assert.Throws<ArgumentException>(() => arg1.BubleSort(new SumElementComparer()));
        }       
    }
}
