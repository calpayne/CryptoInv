using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoInv.Data.Crypto
{
    public class Datum
    {
        public int time { get; set; }
        public string TimeFormatted
        {
            get
            {
                DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddSeconds(time).ToLocalTime();
                return dtDateTime.ToString("dd MMMM");
            }
        }
        public double close { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double open { get; set; }
        public double volumefrom { get; set; }
        public double volumeto { get; set; }
    }

    public class ConversionType
    {
        public string type { get; set; }
        public string conversionSymbol { get; set; }
    }

    public class RateLimit
    {
    }

    public class CryptoAPIHistoryData
    {
        public string Response { get; set; }
        public int Type { get; set; }
        public bool Aggregated { get; set; }
        public List<Datum> Data { get; set; }
        public int TimeTo { get; set; }
        public int TimeFrom { get; set; }
        public bool FirstValueInArray { get; set; }
        public ConversionType ConversionType { get; set; }
        public RateLimit RateLimit { get; set; }
        public bool HasWarning { get; set; }
    }
}
