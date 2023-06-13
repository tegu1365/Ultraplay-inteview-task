using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "Match")]
    public class XMLMatch
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }

        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }

        [XmlAttribute(DataType = "dateTime", AttributeName = "StartDate")]
        public DateTime StartDate { get; set; }

        [XmlAttribute(AttributeName = "MatchType")]
        public string MatchType { get; set; }

        [XmlElement(ElementName = "Bet")]
        public List<XMLBet> Bets { get; set; }
    }
}
