//https://leetcode.com/problems/missing-number/

using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        public int MissingNumber(int[] nums)
        {
            var numsSum = 0;
            foreach (var num in nums)
                numsSum += num;

            var len = nums.Length;
            var realSum = len * (len + 1) / 2;
            return realSum - numsSum;
        }

        [Fact]
        public void TestMissingNumber()
        {
            var arr = new[] {9, 6, 4, 2, 3, 5, 7, 0, 1};
            Assert.Equal(8, MissingNumber(arr));
        }
    }
}