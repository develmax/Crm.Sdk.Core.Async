using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ImportMappingsImportMapRequest : OrganizationRequest
{
    public string MappingsXml
    {
        get
        {
            if (Parameters.Contains("MappingsXml"))
                return (string)Parameters["MappingsXml"];
            return default(string);
        }
        set { Parameters["MappingsXml"] = value; }
    }
    public bool ReplaceIds
    {
        get
        {
            if (Parameters.Contains("ReplaceIds"))
                return (bool)Parameters["ReplaceIds"];
            return default(bool);
        }
        set { Parameters["ReplaceIds"] = value; }
    }
    public ImportMappingsImportMapRequest()
    {
        this.ResponseType = new ImportMappingsImportMapResponse();
        this.RequestName = "ImportMappingsImportMap";
    }
    internal override string GetRequestBody()
    {
        Parameters["MappingsXml"] = MappingsXml;
        Parameters["ReplaceIds"] = ReplaceIds;
        return GetSoapBody();
    }
}