using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LeetCode.aws.ArraysAndStrings
{
    
    //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/902/
    public partial class Solution
    {
        public string MinWindow(string s, string t)
        {
            if (s.Equals(t)) return t;
            var smallestWindowSize = t.Length;
            var hash = new Dictionary<char, int>();
            
            foreach (var character in t)
            {
                if (hash.ContainsKey(character)) hash[character]++;
                else hash.Add(character, 1);
            }

            Dictionary<char, int> CopyDictionary(Dictionary<char, int> old)
            {
                var copy = new Dictionary<char, int>();
                foreach (var character in old.Keys)
                    copy.Add(character, old[character]);

                return copy;
            }

            bool ContainsAllLetters(string windowWord)
            {
                var compareAgainst = CopyDictionary(hash);
                foreach (var character in windowWord)
                    if (compareAgainst.ContainsKey(character)) compareAgainst[character]--;

                foreach(var item in compareAgainst)
                    if (item.Value > 0)
                        return false;
                return true;
            }
            
            for (var windowSize = smallestWindowSize; windowSize <= s.Length; windowSize++)
            {
                for (var i = 0; i < s.Length - windowSize + 1; i++)
                {
                    var windowStr = s.Substring(i, windowSize);
                    var containsLetters = ContainsAllLetters(windowStr);
                    if (containsLetters) return windowStr;
                }
            }
            
            return "";
        }

        [Fact]
        public void TestMinWindow()
        {
            var answer = MinWindow("tkopjjgknziznmfwvkgospwkujjklzugjiwvuefhepiteppbzyptplekwnwjmqqybovvsccyrnuxclyclnvbaznxojgdzydcmyxhacftpbrrnrvyftbfuoelxlozjtbyrbftdkoumhnbzlzgeblarslpdbqoutmnwrgzexvsejtfwulcxzcprqgwrykorxboqkpwhnonyjvuggwdfauyqauiafyseziwjztsojimvdiblegrhdrxdmhetfyxfitqjolaytmtyxwjdeckhuingptbxtyedtumihmgcbbayxkbdomliwyqnrrkmropllbvsqbvtexrdjugyirierzsksewktlxepsyhvvabttecpkayejevkyiedeqwsncjhascwudrnjteuwcahhxtffxkmoggdkpllhpjbvcqevuatzaaiyvpftarjixmtoxgxnraitsoqnpkormwpilxbnomwoypcwvclocvhvlxkajaswwjejghzxtvltmprjrcxwzetldfnnffjdrpoxynurkhmwxefqieoikhvooibvqmyhdpgbcdunkgljktatxqdiaywoizkynkhqzqretntftepgxrzvjcdjcbykcklpwufykycfnvngzcmzvnwerzotcogearvwncuaayfptsvvwkwtzsyrtokveqbgjwexyzxazepvzmqvymryeppxfbuluvrdtvcrwbtwikthwjevxvvdmmcrnyehvvnotrhrvcndmgkirofqkavwmzqcxwluuyinsrentuqfccqwqvocykbmltolpafjaqyshfhbbzidbybuwqwuczgnsxykxgvxwusdbbgcbrfcpjwnzvhbuqqpnrzmxujtqdyrfhvgydkpmjdlemoacgprzqdwnprfssxzz",
            "ufzxqojzrufekhitzcsphr");
            Assert.Equal("abbbbbcdd", answer);
        }
    }
}