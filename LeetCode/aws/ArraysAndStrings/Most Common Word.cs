using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2973/
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var regex = new Regex("\\W");
            var cleanParagraph = regex.Replace(paragraph, " ");
            cleanParagraph = new Regex("\\s+").Replace(cleanParagraph, " ").Trim().ToLower();
            var words = cleanParagraph.Split(" ");
            var freq = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (freq.ContainsKey(word))
                    freq[word]++;
                else if (!banned.Contains(word))
                    freq.Add(word, 1);
            }

            var highest = freq.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            return highest;
        }

        [Fact]
        public void TestMostCommonWord()
        {
            var paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
             Assert.Equal("ball", MostCommonWord(paragraph, new string[]{"hit"}));
        }
    }
}