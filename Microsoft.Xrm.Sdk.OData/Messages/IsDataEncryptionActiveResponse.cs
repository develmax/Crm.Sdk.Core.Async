﻿using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class IsDataEncryptionActiveResponse : OrganizationResponse
{
    public bool IsActive { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "IsActive")
                IsActive = (bool)(result.Element(Util.ns.b + "value"));
        }
    }
}