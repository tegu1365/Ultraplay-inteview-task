using System.Xml;
using System.Xml.Serialization;

namespace ultraplay_task.XMLModels
{
    [XmlRoot(ElementName = "XmlSports")]
    public class XMLElements
    {
            [XmlElement(ElementName = "link")]
            public List<Link> links { get; set; }
            [XmlElement(ElementName = "style")]
            public List<Style> styles { get; set; }
            [XmlElement(ElementName ="Sport")]
            public List<XMLSport> sports { get; set; }
    }

    [XmlRoot(ElementName = "link")]
    public class Link
    {

    }
    [XmlRoot(ElementName = "style")]
    public class Style
    {

    }
}
