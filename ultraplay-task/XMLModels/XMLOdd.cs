using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "Odd")]
    public class XMLOdd
    {
      
        [XmlAttribute(AttributeName = "ID")]
        public int Id { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Value")]
        public double Value { get; set; }
        [XmlAttribute(AttributeName = "SpecialBetValue")]
        public double SpecialBetValue { get; set; }
    }
}
