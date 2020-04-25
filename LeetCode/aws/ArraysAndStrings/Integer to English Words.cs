using System.Collections.Generic;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2972/
    public partial class Solution
    {
        public string OnesConvert(int num)
        { 
            switch(num)
            {
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                default:
                    return "";
            }
        }
        public string TenthsConvert(int num)
        {
            switch (num)
            {
                case 0:
                    return "Ten";
                case 1:
                    return "Eleven";
                case 2:
                    return "Twelve";
                case 3:
                    return "Thirteen";
                case 4:
                    return "Fourteen";
                case 5:
                    return "Fifteen";
                case 6:
                    return "Sixteen";
                case 7:
                    return "Seventeen";
                case 8:
                    return "Eighteen";
                case 9:
                    return "Nineteen";
                default:
                    return "";
            }
        }
        public string TensConvert(int num)
        {
            switch(num)
            {
                case 1:
                    return "Ten";
                case 2:
                    return "Twenty";
                case 3:
                    return "Thirty";
                case 4:
                    return "Forty";
                case 5:
                    return "Fifty";
                case 6:
                    return "Sixty";
                case 7:
                    return "Seventy";
                case 8:
                    return "Eighty";
                case 9:
                    return "Ninety";
                default:
                    return "";
            }
        }
        public string Hundreds(int num)
        {
            switch (num)
            {
                case 2:
                    return "Thousand";
                case 3:
                    return "Million";
                case 4:
                    return "Billion";
                default:
                    return "";
            }
        }
        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";
            void ConvertChunk(int chunk, int chunkCounter, Stack<string> strNum)
            {
                var ones = chunk % 10;
                var tens = chunk/10 % 10;
                var thousands = chunk/100 % 10;

                if (chunkCounter > 1 && (chunk != 0))
                    strNum.Push(Hundreds(chunkCounter));
                if (tens == 1)
                {
                    strNum.Push(TenthsConvert(ones));
                }
                else
                {
                    if (ones != 0)
                        strNum.Push(OnesConvert(ones));
                    if (tens != 0)
                        strNum.Push(TensConvert(tens));
                }

                if (thousands == 0)
                    return;
                    
                strNum.Push("Hundred");
                if (thousands >= 1)
                    strNum.Push(OnesConvert(thousands));
            }

            var chunkCounter = 1;
            var stringNum = new Stack<string>();
            while (num != 0)
            {
                var chunk = num % 1000;
                ConvertChunk(chunk, chunkCounter, stringNum);
                chunkCounter++;
                num /= 1000;
            }

            return string.Join(" ", stringNum);
        }

        [Fact]
        public void TestNumberToWords()
        {
            Assert.Equal("One Hundred Twenty Three", NumberToWords(123));
        }
    }
}