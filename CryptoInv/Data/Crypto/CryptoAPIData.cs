using System.Collections.Generic;

namespace CryptoInv.Data.Crypto
{
    public class PriceRaw
    {
        public string TYPE { get; set; }
        public string MARKET { get; set; }
        public string FROMSYMBOL { get; set; }
        public string TOSYMBOL { get; set; }
        public string FLAGS { get; set; }
        public double PRICE { get; set; }
        public int LASTUPDATE { get; set; }
        public double LASTVOLUME { get; set; }
        public double LASTVOLUMETO { get; set; }
        public string LASTTRADEID { get; set; }
        public double VOLUMEDAY { get; set; }
        public double VOLUMEDAYTO { get; set; }
        public double VOLUME24HOUR { get; set; }
        public double VOLUME24HOURTO { get; set; }
        public double OPENDAY { get; set; }
        public double HIGHDAY { get; set; }
        public double LOWDAY { get; set; }
        public double OPEN24HOUR { get; set; }
        public double HIGH24HOUR { get; set; }
        public double LOW24HOUR { get; set; }
        public string LASTMARKET { get; set; }
        public double VOLUMEHOUR { get; set; }
        public double VOLUMEHOURTO { get; set; }
        public double OPENHOUR { get; set; }
        public double HIGHHOUR { get; set; }
        public double LOWHOUR { get; set; }
        public double CHANGE24HOUR { get; set; }
        public double CHANGEPCT24HOUR { get; set; }
        public double CHANGEDAY { get; set; }
        public double CHANGEPCTDAY { get; set; }
        public double SUPPLY { get; set; }
        public double MKTCAP { get; set; }
        public double TOTALVOLUME24H { get; set; }
        public double TOTALVOLUME24HTO { get; set; }
        public string IMAGEURL { get; set; }
    }

    public class PriceDisplay
    {
        public string FROMSYMBOL { get; set; }
        public string TOSYMBOL { get; set; }
        public string MARKET { get; set; }
        public string PRICE { get; set; }
        public string LASTUPDATE { get; set; }
        public string LASTVOLUME { get; set; }
        public string LASTVOLUMETO { get; set; }
        public string LASTTRADEID { get; set; }
        public string VOLUMEDAY { get; set; }
        public string VOLUMEDAYTO { get; set; }
        public string VOLUME24HOUR { get; set; }
        public string VOLUME24HOURTO { get; set; }
        public string OPENDAY { get; set; }
        public string HIGHDAY { get; set; }
        public string LOWDAY { get; set; }
        public string OPEN24HOUR { get; set; }
        public string HIGH24HOUR { get; set; }
        public string LOW24HOUR { get; set; }
        public string LASTMARKET { get; set; }
        public string VOLUMEHOUR { get; set; }
        public string VOLUMEHOURTO { get; set; }
        public string OPENHOUR { get; set; }
        public string HIGHHOUR { get; set; }
        public string LOWHOUR { get; set; }
        public string CHANGE24HOUR { get; set; }
        public string CHANGEPCT24HOUR { get; set; }
        public string CHANGEDAY { get; set; }
        public string CHANGEPCTDAY { get; set; }
        public string SUPPLY { get; set; }
        public string MKTCAP { get; set; }
        public string TOTALVOLUME24H { get; set; }
        public string TOTALVOLUME24HTO { get; set; }
        public string IMAGEURL { get; set; }
    }

    public class CoinRaw
    {
        public PriceRaw GBP { get; set; }
    }

    public class CoinDisplay
    {
        public PriceDisplay GBP { get; set; }
    }

    public class CryptoAPIData
    {
        public Dictionary<string, CoinRaw> RAW { get; set; }
        public Dictionary<string, CoinDisplay> DISPLAY { get; set; }
    }
}
