using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesAndDragons.BL.Managers
{
    public static class Extensions
    {
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
            var rnd = new Random();

            eigenvalue = rnd.Next(minValue, maxValue);

            return eigenvalue;
        }

        public static int ImpactForce(this int eigenvalue)
        {
            return eigenvalue;
        }
    }
}
