using System;
using System.Diagnostics.CodeAnalysis;
using Geeks.Practices.Helper;

namespace Geeks.Practices.Arrays.Basic
{
    /// <summary>
    /// The title is "Inverse Permutation"
    /// 
    /// Given an array A of size n of integers in the range from 1 to n, we need to find the inverse permutation of that array.
    /// Inverse Permutation is a permutation which you will get
    ///     by inserting position of an element at the position specified by the element value in the array.
    ///     For better understanding, consider the following example:
    ///     Suppose we found element 4 at position 3 in an array,
    ///         then in reverse permutation, we insert 3 (position of element 4 in the array) in position 4 (element value).
    /// 
    /// Input:
    /// The first line of the input contains an integer T denoting the number of test cases.
    /// For each test case,
    ///     the first line contains an integer n, denoting the size of the array A
    ///     followed by n-space separated integers i.e elements of array A.
    /// 
    /// Output:
    /// For each test case, the output is the array after performing inverse permutation on A.
    /// 
    /// Constraints:
    /// 1<=T<=100
    /// 1<=n<=50
    /// 1<=A[i]<=50
    ///
    /// Note: Array should contain unique elements and should have elements from 1 to n. 
    /// 
    /// Example:
    /// 
    /// Input:
    /// 5
    /// 4
    /// 1 4 3 2
    /// 5
    /// 2 3 4 5 1
    /// 5
    /// 2 3 1 5 4
    /// 10
    /// 5 1 8 3 2 4 10 6 7 9 
    /// 10
    /// 6 9 10 1 7 4 8 5 3 2
    /// 
    /// Output:
    /// 1 4 3 2
    /// 5 1 2 3 4
    /// 3 1 2 5 4
    /// 2 5 4 6 1 8 9 3 10 7
    /// 4 10 9 6 8 1 5 7 2 3
    /// 
    /// Explanation:
    /// Test Case 1:
    /// For element 1 we insert position of 1 from arr1 i.e 1 at position 1 in arr2.
    /// For element 4 in arr1, we insert 2 from arr1 at position 4 in arr2.
    /// Similarly, for element 2 in arr1, we insert position of 2 i.e 4 in arr2.
    /// 
    /// Test Case 2:
    /// As index 1 has value 2 so 1 will b placed at index 2
    /// Similarly 2 has 3 so 2 will be placed at index 3
    /// Similarly 3 has 4 so placed at 4
    /// 4 has 5 so 4 placed at 5
    /// And 5 has 1 so placed at index 1
    /// 
    /// </summary>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    [SuppressMessage("ReSharper", "AssignNullToNotNullAttribute")]
    [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
    public class InversePermutation
    {
    }
}