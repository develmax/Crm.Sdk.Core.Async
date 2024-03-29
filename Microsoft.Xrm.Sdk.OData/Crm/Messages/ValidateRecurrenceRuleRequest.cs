using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class ValidateRecurrenceRuleRequest : OrganizationRequest
{
    public Entity Target
    {
        get
        {
            if (Parameters.Contains("Target"))
                return (Entity)Parameters["Target"];
            return default(Entity);
        }
        set { Parameters["Target"] = value; }
    }
    public ValidateRecurrenceRuleRequest()
    {
        this.ResponseType = new ValidateRecurrenceRuleResponse();
        this.RequestName = "ValidateRecurrenceRule";
    }
    internal override string GetRequestBody()
    {
        Parameters["Target"] = Target;
        return GetSoapBody();
    }
}