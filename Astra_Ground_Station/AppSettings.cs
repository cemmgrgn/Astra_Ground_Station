namespace Astra_Ground_Station
{
    internal class AppSettings
    {
        public string RocketCom { get; set; }
        public int RocketBaud { get; set; }
        public string PayloadCom { get; set; }
        public int PayloadBaud { get; set; }
        public string HYICom { get; set; }
        public int HYIBaud { get; set; }
        public int HYIHertz { get; set; }
        public string Camera { get; set; }
        public byte TeamID { get; set; }
        public bool RocketLogEnabled { get; set; }
        public bool PayloadLogEnabled { get; set; }
    }
}