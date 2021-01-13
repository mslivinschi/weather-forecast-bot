using System;

namespace weather_forecast_bot
{
    public class MessageModel
    {
        public Guid Guid {get; set;}

        public DateTime DateTime {get; set;}

        public double Lat {get; set;}
        public double Lon {get; set;}
    }
}