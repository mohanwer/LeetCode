using System;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2967/
        public int ThreeSumClosest(int[] nums, int target) 
        {
            Array.Sort(nums);
            var closestSum = nums[0] + nums[1] + nums[2];
            for (var i = 0; i < nums.Length; i++)
            {
                var low = i + 1;
                var high = nums.Length - 1;
                
                while (low < high)
                {
                    var total = nums[low] + nums[high] + nums[i];
                    if (total == target) return total;
                    if (Math.Abs(target - total) < Math.Abs(target - closestSum))
                        closestSum = total;
                    
                    if (total < target)
                        low++;
                    else
                        high--;
                }
            }

            return closestSum;
        }

        [Fact]
        public void ThreeSumClosestTest()
        {
            var answer = ThreeSumClosest(new[] {0, 2, 1, -3}, 1);
            Assert.Equal(0, answer);
            answer = ThreeSumClosest(new[]{0, 1, 2}, 3);
            Assert.Equal(3, answer);
            answer = ThreeSumClosest(new[] {-1, 2, 1, -4}, 1);
            Assert.Equal(2, answer);
        }
    }
}