﻿namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the SdkMessageFilter.Availability attribute.</summary>
  public static class SdkMessageFilterAvailability
  {
    /// <summary>The message is available only on the server. Value = 0.</summary>
    public const int Server = 0;
    /// <summary>The message is available only on the client. Value = 1.</summary>
    public const int Client = 1;
    /// <summary>The message is available on both connected and disconnected from the server. Value = 2.</summary>
    public const int All = 2;
  }
}
