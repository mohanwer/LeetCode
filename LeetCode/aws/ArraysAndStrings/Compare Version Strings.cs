using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        public int CompareVersion(string version1, string version2)
        {
            List<int> SplitDecimals(string version)
            {
                var splitVersion = version.Split(".");
                var zerosRemoved = new List<int>();
                foreach (var innerVersion in splitVersion)
                {
                    zerosRemoved.Add(int.Parse(innerVersion));
                }

                var trailingZero = zerosRemoved[^1] == 0 && zerosRemoved.Count > 1;
                while (trailingZero)
                {
                    if (zerosRemoved[^1]== 0) zerosRemoved.RemoveAt(zerosRemoved.Count - 1);
                    else trailingZero = zerosRemoved[^1] == 0 && zerosRemoved.Count > 1;;
                }
                return zerosRemoved;
            }

            var version1Split = SplitDecimals(version1);
            var version2Split = SplitDecimals(version2);
            var minArray = Math.Min(version1Split.Count, version2Split.Count);
            var counter = 0;
            var hasNext = true;
            
            while (hasNext)
            {
                if (version1Split[counter] > version2Split[counter])
                    return 1;
                if (version1Split[counter] < version2Split[counter])
                    return -1;
                if (counter + 1 < minArray)
                {
                    counter++;
                }
                else
                {
                    hasNext = false;
                }
            }

            if (version1Split.Count > minArray) return 1;
            if (version2Split.Count > minArray) return -1;
            return 0;
        }

        [Fact]
        public void TestCompareVersion()
        {
            Assert.Equal(0, CompareVersion("1.01", "1.001"));
        }
    }
}