using System;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        // Todo: return to this one.
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2975/
        public int Trap(int[] height)
        {
            var totalTrapped = 0;
            var i = 0;
            while (i < height.Length)
            {
                if (height[i] == 0)
                {
                    i++;
                    continue;
                }
                var scanner = i + 1;
                var nextHeightFound = false;
                var sumOfBlocksInBetweenScan = 0;
                while (!nextHeightFound && scanner < height.Length)
                {
                    if (height[scanner] < height[i])
                    {
                        sumOfBlocksInBetweenScan += height[scanner];
                        scanner++;
                    }
                    else
                        nextHeightFound = true;
                }

                if (nextHeightFound)
                {
                    totalTrapped += (scanner - i - 1) * height[i] - sumOfBlocksInBetweenScan;
                    i = scanner;
                }
                else 
                    i++;
            }

            return totalTrapped;
        }

        [Fact]
        public void TestTrap()
        {
            var input = new int[] {4, 2, 3};
            Assert.Equal(1, Trap(input));
        }
    }
}