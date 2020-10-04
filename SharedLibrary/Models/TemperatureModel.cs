using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Models
{
    public class TemperatureModel
    {
        public double Temperature;
        public double Humidity;

        public TemperatureModel(double aTemperature, double aHumidity)
        {
            Temperature = aTemperature;
            Humidity = aHumidity;
        }
    }
}
