using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  generate a quote from an opportunity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GenerateQuoteFromOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the opportunity to be used as the basis for the new quote. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the opportunity to be used as the basis for the new quote. This corresponds to the Opportunity.OpportunityId attribute, which is the primary key for the Opportunity entity.</returns>
    public Guid OpportunityId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityId)) ? (Guid) this.Parameters[nameof (OpportunityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (OpportunityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the collection of attributes to retrieve in the resulting quote. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The collection of attributes to retrieve in the resulting quote.</returns>
    public ColumnSet ColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (ColumnSet)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.GenerateQuoteFromOpportunityRequest"></see> class.</summary>
    public GenerateQuoteFromOpportunityRequest()
    {
      this.RequestName = "GenerateQuoteFromOpportunity";
      this.OpportunityId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
