namespace Microsoft.Xrm.Sdk.OData.Metadata;

public enum OwnershipTypes
{
    None = 0,
    UserOwned = 1,
    TeamOwned = 2,
    BusinessOwned = 4,
    OrganizationOwned = 8,
    BusinessParented = 16,
}