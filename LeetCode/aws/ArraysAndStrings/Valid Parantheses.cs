// https://leetcode.com/problems/valid-parentheses/

using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2973/
    public partial class Solution
    {
        public bool IsOpener(char character) =>
            character == '[' || character == '(' || character == '{';

        public bool IsCloser(char character) =>
            character == ']' || character == ')' || character == '}';

        public bool IsValidCloser(char opener, char closer) => 
            opener switch
            {
                '[' when closer == ']' => true,
                '{' when closer == '}' => true,
                '(' when closer == ')' => true,
                _ => false
            };
        
        public bool IsValid(string s)
        {
            var parans = new Stack<char>();
            foreach (var character in s)
            {
                if (IsOpener(character))
                    parans.Push(character);
                else if (IsCloser(character))
                {
                    if (parans.Count == 0) return false; 
                    var openedLast = parans.Pop();
                    if (!IsValidCloser(openedLast, character))
                        return false;
                }
            }
            
            return parans.Count == 0;
        }

        [Fact]
        public void TestIsValid()
        {
            Assert.False(IsValid("([)]"));
        }
    }
}