using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveEntityRibbonResponse : OrganizationResponse
{
    public byte[] CompressedEntityXml { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "CompressedEntityXml")
            {
                CompressedEntityXml = System.Convert.FromBase64String(result.Element(Util.ns.b + "value").Value);
            }
        }
    }
}