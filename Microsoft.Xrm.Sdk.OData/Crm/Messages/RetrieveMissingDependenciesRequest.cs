using Microsoft.Xrm.Sdk.OData;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class RetrieveMissingDependenciesRequest : OrganizationRequest
{
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
    public RetrieveMissingDependenciesRequest()
    {
        this.ResponseType = new RetrieveMissingDependenciesResponse();
        this.RequestName = "RetrieveMissingDependencies";
    }
    internal override string GetRequestBody()
    {
        Parameters["SolutionUniqueName"] = SolutionUniqueName;
        return GetSoapBody();
    }
}