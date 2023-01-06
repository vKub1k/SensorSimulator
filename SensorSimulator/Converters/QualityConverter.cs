using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensorSimulator.Converters
{
    /// <summary>
    /// Class <c>QualityConverter</c> converter to work quility sensor field.
    /// </summary>
    public static class QualityConverter
    {
        /// <summary>
        /// Method <c>GetQuality</c> convert value to string value.
        /// </summary>
        public static string GetQuality(int value, int minValue, int maxValue)
        {
            string result;

            var totalValue = maxValue - minValue;

            value -= minValue;
            if (value < 0) value *= -1;

            var percentage = (float)value / totalValue;

            switch (percentage)
            {
                case <= 0.10f:
                case >= 0.90f:
                    result = "Alarm";
                    break;
                case <= 0.25f:
                case >= 0.75f:
                    result = "Warning";
                    break;
                default:
                    result = "Normal";
                    break;
            }

            return result;
        }
    }
}
