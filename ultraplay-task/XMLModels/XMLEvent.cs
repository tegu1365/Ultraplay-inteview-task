using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "Event")]
    public class XMLEvent
    {
       
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "IsLive")]
        public bool IsLive { get; set; }
        [XmlAttribute(AttributeName = "CategoryID")]
        public int CategoryID { get; set; }
        [XmlElement(ElementName = "Match")]
        public List<XMLMatch> Matches { get; set; }
    }
}
