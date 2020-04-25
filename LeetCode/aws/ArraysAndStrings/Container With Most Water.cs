using System;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2963/
        public int MaxArea(int[] height)
        {
            var right = height.Length - 1;
            var left = 0;
            var maxVolume = 0;
            while (left < right)
            {
                var minHeight = Math.Min(height[left], height[right]);
                var potentialHeight = minHeight * (right - left);
                if (potentialHeight > maxVolume) maxVolume = potentialHeight;
                if (height[left] <= height[right])
                    left++;
                else
                    right--;
            }

            return maxVolume;
        }

        [Fact]
        public void TestMaxArea()
        {
            var lineVals = new[] {1,8,6,2,5,4,8,3,7};
            Assert.Equal(49, MaxArea(lineVals));
        }
    }
}