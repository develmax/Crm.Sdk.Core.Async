using Microsoft.Xrm.Sdk.OData.Metadata;

namespace Microsoft.Xrm.Sdk.OData.Messages;

public sealed class CreateOptionSetRequest : OrganizationRequest
{
    public OptionSetMetadataBase OptionSet
    {
        get
        {
            if (Parameters.Contains("OptionSet"))
                return (OptionSetMetadataBase)Parameters["OptionSet"];
            return default(OptionSetMetadataBase);
        }
        set { Parameters["OptionSet"] = value; }
    }
    public string SolutionUniqueName
    {
        get
        {
            if (Parameters.Contains("SolutionUniqueName"))
                return (string)Parameters["SolutionUniqueName"];
            return default(string);
        }
        set { Parameters["SolutionUniqueName"] = value; }
    }
    public CreateOptionSetRequest()
    {
        this.ResponseType = new CreateOptionSetResponse();
        this.RequestName = "CreateOptionSet";
    }
    internal override string GetRequestBody()
    {
        Parameters["OptionSet"] = OptionSet;
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}