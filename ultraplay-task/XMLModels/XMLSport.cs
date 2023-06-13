using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "Sport")]
    public class XMLSport
    {
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "Event")]
        public List<XMLEvent> Events { get; set; }
    }
}
