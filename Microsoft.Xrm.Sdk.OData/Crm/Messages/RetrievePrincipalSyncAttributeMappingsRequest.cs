using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrievePrincipalSyncAttributeMappingsRequest : OrganizationRequest
{
    public EntityReference Principal
    {
        get
        {
            if (Parameters.Contains("Principal"))
                return (EntityReference)Parameters["Principal"];
            return default(EntityReference);
        }
        set { Parameters["Principal"] = value; }
    }
    public RetrievePrincipalSyncAttributeMappingsRequest()
    {
        this.ResponseType = new RetrievePrincipalSyncAttributeMappingsResponse();
        this.RequestName = "RetrievePrincipalSyncAttributeMappings";
    }
    internal override string GetRequestBody()
    {
        Parameters["Principal"] = Principal;
        return GetSoapBody();
    }
}