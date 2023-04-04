﻿namespace Microsoft.Xrm.Sdk.OData.Metadata;

public enum CascadeType
{
    NoCascade = 0,
    Cascade = 1,
    Active = 2,
    UserOwned = 3,
    RemoveLink = 4,
    Restrict = 5
}