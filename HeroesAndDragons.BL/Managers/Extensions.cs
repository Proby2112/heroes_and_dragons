using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace HeroesAndDragons.BL.Managers
{
    public static class Extensions
    {
        readonly static Random _random = new Random();

        /// <summary>
        /// Set eigenvalue within the range.
        /// </summary>
        /// <param name="eigenvalue"></param>
        /// <param name="minValue">Min range value</param>
        /// <param name="maxValue">Max range value</param>
        /// <returns></returns>
        public static int InRange(this int eigenvalue, int minValue, int maxValue)
        {
            if (eigenvalue < minValue)
            {
                eigenvalue = minValue;
            }
            else if (eigenvalue > maxValue)
            {
                eigenvalue = maxValue;
            }

            return eigenvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eigenvalue"></param>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        public static int RandInRange(this int eigenvalue, int minValue, int maxValue)
        {
            eigenvalue = _random.Next(minValue, maxValue);

            return eigenvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eigenvalue"></param>
        /// <returns></returns>
        public static int ImpactForce(this int eigenvalue)
        {
            eigenvalue *= _random.Next(0, 4);

            return eigenvalue;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="eigenvalue"></param>
        /// <param name="requestedLength"></param>
        /// <returns></returns>
        public static string CreateName(this string eigenvalue, int requestedLength)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            string[] consonants = { "b", "c", "d", "f", "g", "h", "j", "k", "l", "m", "n", "p", "q", "r", "s", "t", "v", "w", "x", "y", "z" };
            string[] vowels = { "a", "e", "i", "o", "u" };

            if (requestedLength == 1)
            {
                eigenvalue = GetRandomLetter(_random, vowels);
            }
            else
            {
                for (int i = 0; i < requestedLength; i += 2)
                {
                    eigenvalue += GetRandomLetter(_random, consonants) + GetRandomLetter(_random, vowels);
                }

                eigenvalue = eigenvalue.Replace("q", "qu").Substring(0, requestedLength);
                eigenvalue = textInfo.ToTitleCase(eigenvalue);
            }

            return eigenvalue;
        }

        private static string GetRandomLetter(Random rnd, string[] letters)
        {
            return letters[rnd.Next(0, letters.Length - 1)];
        }
    }
}
