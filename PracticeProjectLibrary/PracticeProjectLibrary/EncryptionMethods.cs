using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProjectLibrary
{
    public class EncryptionMethods
    {
        static string encrypt(string message, int shift)
        {
            List<char> charList = message.ToList();
            for (int i = 0; i < charList.Count; i++)
            {
                char letter = charList[i];
                if (!Char.IsLetter(letter))
                {
                    if (Char.IsDigit(letter))
                    {
                        string s = letter.ToString();
                        shift = Int16.Parse(s) + shift;
                    }
                }
                else
                {
                    if ((char)(letter + shift) > 'z')
                        charList[i] = (char)('a' + ((letter + shift) % 'z' - 1));
                    else
                        charList[i] = (char)(letter + shift);
                }
            }
            return new string(charList.ToArray());
        }  
    }
}
