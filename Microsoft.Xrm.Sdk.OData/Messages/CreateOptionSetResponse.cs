﻿using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class CreateOptionSetResponse : OrganizationResponse
{
    public Guid OptionSetId { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "OptionSetId")
                this.OptionSetId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
        }
    }
}