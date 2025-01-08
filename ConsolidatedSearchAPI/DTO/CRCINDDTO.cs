using System.Xml.Serialization;

namespace ConsolidatedSearchAPI.DTO;

[XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
public class Envelope
{
    [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public Body? Body { get; set; }
}

public class Body
{
    [XmlElement(ElementName = "GetByNameResponse", Namespace = "http://tempuri.org")]
    public GetByNameResponse? GetByNameResponse { get; set; }
}

public class GetByNameResponse
{
    [XmlElement(ElementName = "GetByNameResult", Namespace = "http://tempuri.org")]
    public GetByNameResult? GetByNameResult { get; set; }
}

public class GetByNameResult
{
    [XmlElement(ElementName = "diffgram", Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1")]
    public Diffgram? Diffgram { get; set; }
}

public class Diffgram
{
    [XmlElement(ElementName = "ListByName", Namespace = "")]
    public ListByName? ListByName { get; set; }
}

public class ListByName
{
    [XmlElement(ElementName = "SQL", Namespace = "")]
    public SQL[]? SQLItems { get; set; }
}

public class SQL
{
    [XmlElement(ElementName = "ID", Namespace = "")]
    public long ID { get; set; }

    [XmlElement(ElementName = "Name", Namespace = "")]
    public string? Name { get; set; }

    [XmlElement(ElementName = "DOB", Namespace = "")]
    public DateTime? DOB { get; set; }

    [XmlElement(ElementName = "SSN", Namespace = "")]
    public string? SSN { get; set; }
}
