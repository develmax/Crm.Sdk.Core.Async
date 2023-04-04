using System.Xml.Linq;
using Microsoft.Xrm.Sdk.OData;
using Microsoft.Xrm.Sdk.OData.Utility;

namespace Microsoft.Xrm.Sdk.OData.Metadata;

public sealed class EntityMetadataCollection : DataCollection<EntityMetadata>
{
    static internal EntityMetadataCollection LoadFromXml(XElement item)
    {
        EntityMetadataCollection entityMetadataCollection = new EntityMetadataCollection();
        foreach (var entity in item.Elements(Util.ns.a + "EntityMetadata"))
        {
            entityMetadataCollection.Add(EntityMetadata.LoadFromXml(entity));
        }
        return entityMetadataCollection;
    }
}