using System.Xml.Serialization;

namespace Cheese_Clicker.PlayerClasses
{
    [XmlRoot("PlayerData")]
    public class StatisitcsManager
    {
        [XmlElement("PlayerMoney")]
        public long money { get; set; } = 0L;

        [XmlElement("clickCount")]
        public int clickCount { get; set; } = 0;

        [XmlElement("profileName")]
        public string profileName { get; set; } = "LocalProfile";

        public StatisitcsManager()
        {
            profileName = "GameSave";
            clickCount = 0;
            money = 1000;
        }

        public StatisitcsManager(long inMoney, int inClickCount)
        {
            money = inMoney;
            clickCount = inClickCount;
        }

        public void IncrementClickCount()
        {
            clickCount += 1;
        }

        public void AddMoney(long amount)
        {
            money += amount;
        }

        public void RemoveMoney(long amount)
        {
            money -= amount;
        }
    }
}
