using System;
using System.Linq;

public static class RotationalCipher
{
    public static string Rotate(string plainText, int shiftKey)
    {
        Func<int, int, int> cipherFunc = (x,n) => (x + n) % 26;

        var lowerAlphabet = "abcdefghijklmnopqrstuvwxyz";
        Func<char, int> lowerIndexFunc = (l) => lowerAlphabet.IndexOf(l);
        var upperAlphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Func<char, int> upperIndexFunc = (l) => upperAlphabet.IndexOf(l);

        Func<char, char> ciphedCharFunc = (l) =>
        {
            var ciphedChar = l;

            if (char.IsLower(l))
            {
                var index = lowerIndexFunc(l);
                ciphedChar = lowerAlphabet[cipherFunc(index,shiftKey)];
            }
            else if (char.IsUpper(l))
            {
                var index = upperIndexFunc(l);
                ciphedChar = upperAlphabet[cipherFunc(index,shiftKey)];
            }

            return ciphedChar;
        };

        var cipherText = string.Join("", plainText.ToCharArray().Select(l => ciphedCharFunc(l)));

        return cipherText;
    }
}