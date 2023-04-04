namespace Microsoft.Xrm.Sdk.OData.Metadata;

public enum ManagedPropertyOperation
{
    None,
    Create,
    Update,
    Delete = 4,
    CreateUpdate = 3,
    UpdateDelete = 6,
    All
}