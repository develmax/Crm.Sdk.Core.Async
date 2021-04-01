﻿using Microsoft.Xrm.Sdk.Query;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Provides programmatic access to the metadata and data for an organization.</summary>
    [ServiceContract(Name = "IOrganizationService", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Services")]
    [KnownAssembly]
    public interface IOrganizationService
    {
        /// <summary>Creates a record. </summary>
        /// <returns>Type:Returns_Guid
        /// The ID of the newly created record.</returns>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that contains the properties to set in the newly created record.</param>
        [FaultContract(typeof(OrganizationServiceFault))]
        [OperationContract]
        Task<Guid> Create(Entity entity);

        /// <summary>Retrieves a record.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>
        /// The requested entity.</returns>
        /// <param name="id">Type: Returns_Guid. The ID of the record that you want to retrieve.</param>
        /// <param name="columnSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>. A query that specifies the set of columns, or attributes, to retrieve. </param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity that is specified in the entityId parameter.</param>
        [FaultContract(typeof(OrganizationServiceFault))]
        [OperationContract]
        Task<Entity> Retrieve(string entityName, Guid id, ColumnSet columnSet);

        /// <summary>Updates an existing record.</summary>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that has one or more properties set to be updated in the record.</param>
        [OperationContract]
        [FaultContract(typeof(OrganizationServiceFault))]
        Task Update(Entity entity);

        /// <summary>Deletes a record.</summary>
        /// <param name="id">Type: Returns_Guid. The ID of the record that you want to delete.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity that is specified in the entityId parameter.</param>
        [OperationContract]
        [FaultContract(typeof(OrganizationServiceFault))]
        Task Delete(string entityName, Guid id);

        /// <summary>Executes a message in the form of a request, and returns a response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>The response from the request. You must cast the return value of this method to the specific instance of the response that corresponds to the Request parameter.</returns>
        /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. A request instance that defines the action to be performed.</param>
        [FaultContract(typeof(OrganizationServiceFault))]
        [OperationContract]
        Task<OrganizationResponse> Execute(OrganizationRequest request);

        /// <summary>Creates a link between records.</summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. property_relatedentities to be associated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to create the link. </param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. property_entityid to which the related records are associated.</param>
        [OperationContract]
        [FaultContract(typeof(OrganizationServiceFault))]
        Task Associate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities);

        /// <summary>Deletes a link between records.</summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. A collection of entity references (references to records) to be disassociated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to remove the link.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. The ID of the record from which the related records are disassociated.</param>
        [FaultContract(typeof(OrganizationServiceFault))]
        [OperationContract]
        Task Disassociate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities);

        /// <summary>Retrieves a collection of records.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of entities returned from the query.</returns>
        /// <param name="query">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>. A query that determines the set of records to retrieve.</param>
        [OperationContract]
        [FaultContract(typeof(OrganizationServiceFault))]
        Task<EntityCollection> RetrieveMultiple(QueryBase query);
    }
}