using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.OData;

public sealed class ErrorDetailCollection : DataCollection<string, object>
{
    static internal ErrorDetailCollection LoadFromXml(XElement item)
    {
        ErrorDetailCollection errorDetailCollection = new ErrorDetailCollection()
        {

        };
        return errorDetailCollection;
    }
}