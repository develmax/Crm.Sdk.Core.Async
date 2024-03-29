using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AssociateEntitiesRequest : OrganizationRequest
{
    public EntityReference Moniker1
    {
        get
        {
            if (Parameters.Contains("Moniker1"))
                return (EntityReference)Parameters["Moniker1"];
            return default(EntityReference);
        }
        set { Parameters["Moniker1"] = value; }
    }
    public EntityReference Moniker2
    {
        get
        {
            if (Parameters.Contains("Moniker2"))
                return (EntityReference)Parameters["Moniker2"];
            return default(EntityReference);
        }
        set { Parameters["Moniker2"] = value; }
    }
    public string RelationshipName
    {
        get
        {
            if (Parameters.Contains("RelationshipName"))
                return (string)Parameters["RelationshipName"];
            return default(string);
        }
        set { Parameters["RelationshipName"] = value; }
    }
    public AssociateEntitiesRequest()
    {
        this.ResponseType = new AssociateEntitiesResponse();
        this.RequestName = "AssociateEntities";
    }
    internal override string GetRequestBody()
    {
        Parameters["Moniker1"] = Moniker1;
        Parameters["Moniker2"] = Moniker2;
        Parameters["RelationshipName"] = RelationshipName;
        return GetSoapBody();
    }
}