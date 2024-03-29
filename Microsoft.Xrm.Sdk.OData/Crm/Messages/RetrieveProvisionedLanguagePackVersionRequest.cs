using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveProvisionedLanguagePackVersionRequest : OrganizationRequest
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
    public RetrieveProvisionedLanguagePackVersionRequest()
    {
        this.ResponseType = new RetrieveProvisionedLanguagePackVersionResponse();
        this.RequestName = "RetrieveProvisionedLanguagePackVersion";
    }
    internal override string GetRequestBody()
    {
        Parameters["Language"] = Language;
        return GetSoapBody();
    }
}