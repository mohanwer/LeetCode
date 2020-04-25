using System;
using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2970/
        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            if (strs.Length == 0) return new List<IList<string>>();;
            var words = new Dictionary<string, List<string>>();
            foreach (var anagram in strs)
            {
                var splitAna = anagram.ToCharArray();
                Array.Sort(splitAna);
                var alphaWord = new string(splitAna);
                if (words.ContainsKey(alphaWord))
                    words[alphaWord].Add(anagram);
                else
                {
                    words.Add(alphaWord, new List<string>(){anagram});
                }
            }

            return new List<IList<string>>(words.Values);
        }

        [Fact]
        public void TestGroupAnagrams()
        {
            var words = new string[] { "eat","tea","tan","ate","nat","bat" };
            var answer = new List<List<string>>
            {
                new List<string>() {"bat"},
                new List<string>() {"nat","tan"},
                new List<string>() {"ate","eat","tea"},
            };
            Assert.Equal(answer, GroupAnagrams(words));
        }
    }
}