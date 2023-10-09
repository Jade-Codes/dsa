public class Solution {
    public string ReverseWords(string s) {

        var sArray = s.Split(' ');

        var newSArray = new string[sArray.Length];

        for(var i=0; i<sArray.Length; i++)
        {
            char[] charArray = new char[sArray[i].Length];
            int forward = 0;
            for (int j = sArray[i].Length - 1; j >= 0; j--)
            {
                charArray[forward++] = sArray[i][j];
            }
            newSArray[i] = new string(charArray);
        }

        return string.Join(' ', newSArray);
    }
}