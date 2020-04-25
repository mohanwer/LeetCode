using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/499/
        public int[] ProductExceptSelf(int[] nums)
        {
            var result = new int[nums.Length];
            result[0] = 1;
            for (var i = 1; i < nums.Length; i++)
            {
                result[i] = nums[i - 1] * result[i - 1];
            }

            var R = 1;
            for (var i = nums.Length - 1; i >= 0; i--)
            {
                result[i] = result[i] * R;
                R *= nums[i];
            }

            return result;
        }

        [Fact]
        public void TestProductExceptSelf()
        {
            var answer = new int[] {24, 12, 8, 6};
            Assert.Equal(answer, ProductExceptSelf(new int[] {1, 2, 3, 4}));
        }
    }
}