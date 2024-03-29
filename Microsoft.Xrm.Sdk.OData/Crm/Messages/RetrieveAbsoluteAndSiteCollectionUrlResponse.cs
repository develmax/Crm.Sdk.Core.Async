using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveAbsoluteAndSiteCollectionUrlResponse : OrganizationResponse
{
    public string AbsoluteUrl { get; set; }
    public string SiteCollectionUrl { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "AbsoluteUrl")
                this.AbsoluteUrl = result.Element(Util.ns.b + "value").Value;
            else if (result.Element(Util.ns.b + "key").Value == "SiteCollectionUrl")
                this.SiteCollectionUrl = result.Element(Util.ns.b + "value").Value;
        }
    }
}