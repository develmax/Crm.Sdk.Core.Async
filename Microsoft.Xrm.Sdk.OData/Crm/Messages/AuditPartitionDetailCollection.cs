using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Crm.Sdk.OData.Messages;

public sealed class AuditPartitionDetailCollection : DataCollection<AuditPartitionDetail>
{
    public bool IsLogicalCollection { get; set; }
    static internal AuditPartitionDetailCollection LoadFromXml(XElement item)
    {
        // Omit IsLogicalCollection parsing as service doesn't return the result.
        AuditPartitionDetailCollection auditPartitionDetailCollection = new AuditPartitionDetailCollection()
        {
            IsLogicalCollection = false
        };
        foreach (var auditPartitionDetail in item.Elements(Util.ns.g + "AuditPartitionDetail"))
        {
            auditPartitionDetailCollection.Add(AuditPartitionDetail.LoadFromXml(auditPartitionDetail));
        }
        return auditPartitionDetailCollection;
    }
}