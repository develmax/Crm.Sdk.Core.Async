using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ProvisionLanguageRequest : OrganizationRequest
{
    public int Language
    {
        get
        {
            if (Parameters.Contains("Language"))
                return (int)Parameters["Language"];
            return default(int);
        }
        set { Parameters["Language"] = value; }
    }
    public ProvisionLanguageRequest()
    {
        this.ResponseType = new ProvisionLanguageResponse();
        this.RequestName = "ProvisionLanguage";
    }
    internal override string GetRequestBody()
    {
        Parameters["Language"] = Language;
        return GetSoapBody();
    }
}