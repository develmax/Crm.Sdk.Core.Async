using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GenerateSalesOrderFromOpportunityRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GenerateSalesOrderFromOpportunityResponse : OrganizationResponse
  {
    /// <summary>Gets the resulting sales order (order).</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The resulting sales order (order), which must be an instance of the SalesOrder class.</returns>
    public Entity Entity
    {
      get
      {
        return this.Results.Contains(nameof (Entity)) ? (Entity) this.Results[nameof (Entity)] : (Entity) null;
      }
    }
  }
}
