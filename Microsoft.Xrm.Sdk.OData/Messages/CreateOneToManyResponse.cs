﻿using System;
using System.Net.Http;
using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class CreateOneToManyResponse : OrganizationResponse
{
    public Guid AttributeId { get; set; }
    public Guid RelationshipId { get; set; }
    internal override void StoreResult(HttpResponseMessage httpResponse)
    {
        // Convert to XDocument
        XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
        // Obtain Values from result.
        foreach (var result in xdoc.Descendants(Util.ns.a + "Results").Elements(Util.ns.a + "KeyValuePairOfstringanyType"))
        {
            if (result.Element(Util.ns.b + "key").Value == "AttributeId")
                this.AttributeId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
            if (result.Element(Util.ns.b + "key").Value == "RelationshipId")
                this.RelationshipId = Util.LoadFromXml<Guid>(result.Element(Util.ns.b + "value"));
        }
    }
}