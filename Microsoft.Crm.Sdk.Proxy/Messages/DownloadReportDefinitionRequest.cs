﻿using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  download a report definition.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DownloadReportDefinitionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the report to download.</summary>
    /// <returns>Type: Returns_GuidThe ID of the report to download. This corresponds to the Report.ReportId attribute, which is the primary key for the Report entity.</returns>
    public Guid ReportId
    {
      get
      {
        return this.Parameters.Contains(nameof (ReportId)) ? (Guid) this.Parameters[nameof (ReportId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ReportId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.DownloadReportDefinitionRequest"></see> class.</summary>
    public DownloadReportDefinitionRequest()
    {
      this.RequestName = "DownloadReportDefinition";
      this.ReportId = new Guid();
    }
  }
}
