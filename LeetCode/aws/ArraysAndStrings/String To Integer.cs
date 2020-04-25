using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public partial class Solution
    {
        //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2962/
        public int MyAtoi(string str)
        {
            var scanContinue = true;
            var digitFound = false;
            var negative = false;
            double digits = 0;
            var len = str.Length;
            var i = 0;
            var digitsFound = 0;
            bool isDigit(char character) =>
                char.IsDigit(character);
                
            while (i < len && scanContinue)
            {
                if (!char.IsWhiteSpace(str[i]) && !isDigit(str[i]) && str[i] != '-' && str[i] != '+')
                    scanContinue = false;
                else if (str[i] == '+' && !digitFound) digitFound = true;
                else if (str[i] == '-' && !negative && !digitFound)
                {
                    digitFound = true;
                    negative = true;
                }
                else if (!digitFound && isDigit(str[i]))
                {
                    digitFound = true;
                    digits += str[i] - 48;
                    digitsFound = 1;
                } else if (digitFound && !isDigit(str[i]))
                    scanContinue = false;
                else if (isDigit(str[i]))
                {
                    digits = (str[i] - 48) + (digits * 10);
                    digitsFound++;
                }
                i++;
            }

            if (negative) digits *= -1;
            if (digits < int.MinValue) return int.MinValue;
            if (digits > int.MaxValue) return int.MaxValue;
            
            return (int)digits;
        }

        [Fact]
        public void TestAtoi()
        {
            Assert.Equal(42, MyAtoi("+42"));
            Assert.Equal(1, MyAtoi("+1"));
            Assert.Equal(4193, MyAtoi("4193 with words"));
            Assert.Equal(0, MyAtoi("words and 987"));
            Assert.Equal(int.MinValue, MyAtoi("-91283472332"));
            Assert.Equal(0, MyAtoi("+-2"));
        }
    }
}