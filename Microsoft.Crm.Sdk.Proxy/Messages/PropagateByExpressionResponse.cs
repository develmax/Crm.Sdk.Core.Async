using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.PropagateByExpressionRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PropagateByExpressionResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the bulk operation that is created to distribute the campaign activity. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the bulk operation that is created to distribute the campaign activity. This corresponds to the BulkOperation.ActivityId attribute, which is the primary key for the BulkOperation entity.</returns>
    public Guid BulkOperationId
    {
      get
      {
        return this.Results.Contains(nameof (BulkOperationId)) ? (Guid) this.Results[nameof (BulkOperationId)] : new Guid();
      }
    }
  }
}
