using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2966/
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            var results = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; ++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                var target = 0 - nums[i];
                var low = i + 1;
                var high = nums.Length - 1;

                while (low < high)
                {
                    if (low != i + 1 && nums[low] == nums[low - 1])
                    {
                        low++;
                        continue;
                    }

                    if (high != nums.Length - 1 && nums[high] == nums[high + 1])
                    {
                        --high;
                        continue;
                    }

                    var tempSum = nums[high] + nums[low];

                    if (tempSum == target)
                    {
                        results.Add(new List<int> { nums[i], nums[low], nums[high] });
                        low++;
                        high--;
                    } else if (tempSum < target)
                        low++;
                    else
                        high--;
                }
            }

            return results;
        }

        [Fact]
        public void TestThreeSum()
        {
            var array = new[] {-2, 0, 1, 1, 2};
            var answer = new List<List<int>>();
            var firstSet = new List<int> {-2, 0, 2};
            var secondSet = new List<int> {-2, 1, 1};
            answer.Add(firstSet);
            answer.Add(secondSet);
            Assert.Equal(answer, ThreeSum(array));
        }
    }
}