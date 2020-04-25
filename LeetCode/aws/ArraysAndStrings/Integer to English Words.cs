using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        public string OnesConvert(int num)
        { 
            switch(num)
            {
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    return "";
            }
        }
        public string TenthsConvert(int num)
        {
            switch (num)
            {
                case 1:
                    return "eleven";
                case 2:
                    return "twelve";
                case 3:
                    return "thirteen";
                case 4:
                    return "fourteen";
                case 5:
                    return "fifteen";
                case 6:
                    return "sixteen";
                case 7:
                    return "seventeen";
                case 8:
                    return "eighteen";
                case 9:
                    return "nineteen";
                default:
                    return "";
            }
        }
        public string TensConvert(int num)
        {
            switch(num)
            {
                case 1:
                    return "ten";
                case 2:
                    return "twenty";
                case 3:
                    return "thirty";
                case 4:
                    return "fourty";
                case 5:
                    return "fifty";
                case 6:
                    return "sixty";
                case 7:
                    return "sevenity";
                case 8:
                    return "eighty";
                case 9:
                    return "ninety";
                default:
                    return "";
            }
        }
        public string Hundreds(int num)
        {
            switch (num)
            {
                case 1:
                    return "hundred";
                case 2:
                    return "thousand";
                case 3:
                    return "million";
                case 4:
                    return "billion";
                default:
                    return "";
            }
        }
        public string NumberToWords(int num)
        {
            string ConvertChunk(int chunk, int chunkCounter)
            {
                var ones = chunk % 10;
                var tens = chunk/10 % 10;
                var thousands = chunk/100 % 10;

                var strNum = new List<string>();
                
                strNum.Add(OnesConvert(ones));
                
                if (thousands == 0)
                    strNum.Add(Hundreds(chunk));
                
                if (tens == 1)
                    strNum.Add(TenthsConvert(tens));
                else
                    strNum.Add(TensConvert(tens));

                if (thousands == 0) return strNum.ToString();
                
                strNum.Add(Hundreds(chunkCounter));
                strNum.Add(OnesConvert(thousands));

                return String.Join(" ", strNum);
            }

            var chunkCounter = 1;
            var stringNum = new StringBuilder();
            while (num != 0)
            {
                var chunk = num % 1000;
                var numWord = ConvertChunk(chunk, chunkCounter);
                stringNum.Append(stringNum);
                num %= 1000;
            }

            return stringNum.ToString();
        }

        [Fact]
        public void TestNumberToWords()
        {
            Assert.Equal("Twelve Thousand Three Hundred Forty Five", NumberToWords(12345));
        }
    }
}