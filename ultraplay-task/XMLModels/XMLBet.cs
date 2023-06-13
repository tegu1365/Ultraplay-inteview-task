using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "Bet")]
    public class XMLBet
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "IsLive")]
        public bool IsLive { get; set; }
        [XmlElement(ElementName = "Odd")]
        public List<XMLOdd> Odds { get; set; }
    }
}
