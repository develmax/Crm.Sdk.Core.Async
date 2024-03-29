using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class FetchXmlToQueryExpressionRequest : OrganizationRequest
{
    public string FetchXml
    {
        get
        {
            if (Parameters.Contains("FetchXml"))
                return (string)Parameters["FetchXml"];
            return default(string);
        }
        set { Parameters["FetchXml"] = value; }
    }
    public FetchXmlToQueryExpressionRequest()
    {
        this.ResponseType = new FetchXmlToQueryExpressionResponse();
        this.RequestName = "FetchXmlToQueryExpression";
    }
    internal override string GetRequestBody()
    {
        Parameters["FetchXml"] = FetchXml;
        return GetSoapBody();
    }
}