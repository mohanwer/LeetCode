//https://leetcode.com/problems/reorder-data-in-log-files/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    public class LogFile: IComparable<LogFile>
    {
        public string Identifier { get; set; }
        public string LogData { get; set; }
        public bool IsDigitLog { get; set; }
        public string FullLog => $"{Identifier} {LogData}";
        
        public int CompareTo(LogFile other)
        {
            var logCompare = String.Compare(LogData, other.LogData);
            if (logCompare != 0) return logCompare;
            return String.Compare(Identifier, other.Identifier);
        }
    }
    
    public partial class Solution
    {
        public bool IsNum(string number)
        {
            foreach (var num in number)
            {
                if (num >= '0' && num <= '9')
                    continue;
                else
                    return false;
            }

            return true;
        }
        
        public string[] ReorderLogFiles(string[] logs)
        {
            var logList = new List<LogFile>();
            var digList = new List<LogFile>();
            foreach (var log in logs)
            {
                var logItems = log.Split(" ").ToList();
                var identifier = logItems[0];
                var isDigital = IsNum(logItems[1]);
                var data = string.Join(" ", logItems.GetRange(1, logItems.Count - 1));
                var logRecord = new LogFile {IsDigitLog = isDigital, Identifier = identifier, LogData = data};
                if (isDigital)
                    digList.Add(logRecord);
                else
                    logList.Add(logRecord);
            }
            logList.Sort();
            logList.AddRange(digList);
            var result = logList.Select(l => l.FullLog).ToArray();
            return result;
        }

        [Fact]
        public void TestReorderLogFiles()
        {
            var logs = new string[] {"l5sh 6 3869 08 1295", "16o 94884717383724 9", "43 490972281212 3 51", "9 ehyjki ngcoobi mi", "2epy 85881033085988", "7z fqkbxxqfks f y dg", "9h4p 5 791738 954209", "p i hz uubk id s m l", "wd lfqgmu pvklkdp u", "m4jl 225084707500464", "6np2 bqrrqt q vtap h", "e mpgfn bfkylg zewmg", "ttzoz 035658365825 9", "k5pkn 88312912782538", "ry9 8231674347096 00", "w 831 74626 07 353 9", "bxao armngjllmvqwn q", "0uoj 9 8896814034171", "0 81650258784962331", "t3df gjjn nxbrryos b"};
            var answer = new string[] {"bxao armngjllmvqwn q","6np2 bqrrqt q vtap h","9 ehyjki ngcoobi mi","7z fqkbxxqfks f y dg","t3df gjjn nxbrryos b","p i hz uubk id s m l","wd lfqgmu pvklkdp u","e mpgfn bfkylg zewmg","l5sh 6 3869 08 1295","16o 94884717383724 9","43 490972281212 3 51","2epy 85881033085988","9h4p 5 791738 954209","m4jl 225084707500464","ttzoz 035658365825 9","k5pkn 88312912782538","ry9 8231674347096 00","w 831 74626 07 353 9","0uoj 9 8896814034171","0 81650258784962331"};
            Assert.Equal(answer, ReorderLogFiles(logs));
        }
    }
}