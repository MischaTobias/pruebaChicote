using System.Text;
using System.Xml.Serialization;
using ConsolidatedSearchAPI.DTO;
using ConsolidatedSearchAPI.Models;

namespace ConsolidatedSearchAPI.Services;

public class CRCINDService(HttpClient httpClient, IConfiguration configuration) : ISearchService
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly string _crcindBaseUrl = configuration.GetValue<string>("ApiSettings:CRCINDBaseUrl") ?? "";

    public async Task<List<SearchResult>> SearchAsync(string query)
    {
        // SOAP Envelope (make sure to adjust the body accordingly)
        string soapRequest = $@"
            <soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:tem=""http://tempuri.org"">
                <soapenv:Header/>
                <soapenv:Body>
                    <tem:GetByName>
                        <tem:name>{query}</tem:name>
                    </tem:GetByName>
                </soapenv:Body>
            </soapenv:Envelope>";

        // Create a HttpRequestMessage
        var request = new HttpRequestMessage(HttpMethod.Post, _crcindBaseUrl)
        {
            Content = new StringContent(soapRequest, Encoding.UTF8, "text/xml")
        };

        // Add necessary headers for SOAP request
        request.Headers.Add("SOAPAction", "http://tempuri.org/GetByName");

        // Send the request and get the response
        var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();

        // Read the XML response
        var xmlResponse = await response.Content.ReadAsStringAsync();

        // Deserialize the XML response to the appropriate C# object
        var serializer = new XmlSerializer(typeof(Envelope), "http://schemas.xmlsoap.org/soap/envelope/");
        using var reader = new StringReader(xmlResponse);
        var envelope = (Envelope)serializer.Deserialize(reader);

        var results = envelope?.Body?.GetByNameResponse?.GetByNameResult?.Diffgram?.ListByName?.SQLItems;

        if (results == null || results.Length == 0)
        {
            return [];
        }

        return results.Select(r => new SearchResult
        {
            Source = "CRCIND",
            Title = r.Name ?? "Unknown Title",
            Description = $"ID: {r.ID}, DOB: {r.DOB?.ToShortDateString()}, SSN: {r.SSN}",
            Url = "Not Available"
        }).ToList();
    }
}