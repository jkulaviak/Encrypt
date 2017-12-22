using System;
using System.Collections.Generic;
using System.Text;

namespace Encrypt.Bl.Algorithms
{
    public class MorseAlgorithm
    {

        private static Dictionary<char, string> _alphabetToMorseDictionary = new Dictionary<char, string>
        {
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'0', "-----"},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."}
        };

        private static Dictionary<string, char> _morseToAlphabetDictionary;

        private static Dictionary<string, char> InvertDictionary(Dictionary<char, string> dict)
        {
            var ret = new Dictionary<string, char>();
            foreach (var pair in dict)
            {
                ret.Add(pair.Value, pair.Key);
            }
            return ret;
        }

        public MorseAlgorithm()
        {
            _morseToAlphabetDictionary = InvertDictionary(_alphabetToMorseDictionary);
        }

        /// <summary>
        /// Encrypts the specified string.
        /// </summary>
        public string Encrypt(string str)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            { 
                var ch = Char.ToUpper(str[i]);
                if (ch != ' ')
                {
                    string translatedCh;
                    if (_alphabetToMorseDictionary.TryGetValue(ch, out translatedCh))
                    {
                        sb.Append(translatedCh);
                        if (i != str.Length - 1)
                        {
                            sb.Append(" ");    
                        }
                    }
                }
                else
                {                    
                    sb.Append("/ ");
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Decrypts the specified string.
        /// </summary>
        public string Decrypt(string str)
        {
            var sb = new StringBuilder();
            var encryptedCharSb = new StringBuilder();
            foreach (var ch in str)
            {
                switch (ch)
                {
                    case '/':
                        sb.Append(" ");
                        break;
                    case ' ':
                        if (encryptedCharSb.Length > 0)
                        {
                            var decryptedChar = MorseToChar(encryptedCharSb.ToString());
                            if (decryptedChar != null)
                            {
                                sb.Append(decryptedChar);                                
                            }
                            encryptedCharSb = new StringBuilder();                            
                        }
                        break;
                    default:
                        if (ch == '.' || ch == '-')
                        {
                            encryptedCharSb.Append(ch);                                                
                        }
                        break;
                }
            }
            if (encryptedCharSb.Length > 0)
            {
                var decryptedChar = MorseToChar(encryptedCharSb.ToString());
                if (decryptedChar != null)
                {
                    sb.Append(decryptedChar);                                
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Translates morse sequence to character.
        /// </summary>
        private char? MorseToChar(string str)
        {
            char ch;
            if (_morseToAlphabetDictionary.TryGetValue(str, out ch))
            {
                return ch;
            }
            else
            {
                return null;
            }
        }
    }
}