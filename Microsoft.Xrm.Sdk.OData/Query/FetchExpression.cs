using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Xrm.Sdk.OData.Query;

public sealed class FetchExpression : QueryBase
{
    public string Query { get; set; }
    public FetchExpression() { }
    public FetchExpression(string Query)
    {
        this.Query = Query;
    }
    internal string ToValueXml()
    {
        return Util.ObjectToXml(Query, "a:Query", true);
    }
}