﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  search for knowledge base articles that contain the specified title.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SearchByTitleKbArticleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the title in the articles. Required.</summary>
    /// <returns>Type: Returns_StringThe title of the article.</returns>
    public string SearchText
    {
      get
      {
        return this.Parameters.Contains(nameof (SearchText)) ? (string) this.Parameters[nameof (SearchText)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SearchText)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the subject for the knowledge base article. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the knowledge base article subject. This corresponds to the Subject.SubjectId attribute, which is the primary key for the Subject entity.</returns>
    public Guid SubjectId
    {
      get
      {
        return this.Parameters.Contains(nameof (SubjectId)) ? (Guid) this.Parameters[nameof (SubjectId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SubjectId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to use inflectional stem matching when you search for knowledge base articles by a specific title. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to use inflectional stem matching when searching for knowledge base articles with a specified title. true, to use inflectional stem matching, otherwise, false.</returns>
    public bool UseInflection
    {
      get
      {
        return this.Parameters.Contains(nameof (UseInflection)) && (bool) this.Parameters[nameof (UseInflection)];
      }
      set
      {
        this.Parameters[nameof (UseInflection)] = (object) value;
      }
    }

    /// <summary>Gets or sets the query criteria to find knowledge base articles with the specified title. Required. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query criteria to find knowledge base articles with the specified title.</returns>
    public QueryBase QueryExpression
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryExpression)) ? (QueryBase) this.Parameters[nameof (QueryExpression)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (QueryExpression)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SearchByTitleKbArticleRequest"></see> class.</summary>
    public SearchByTitleKbArticleRequest()
    {
      this.RequestName = "SearchByTitleKbArticle";
      this.SearchText = (string) null;
      this.SubjectId = new Guid();
      this.UseInflection = false;
      this.QueryExpression = (QueryBase) null;
    }
  }
}
