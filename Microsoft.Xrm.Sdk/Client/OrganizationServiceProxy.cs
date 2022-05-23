using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Implements <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see> and provides an authenticated WCF channel to the organization service.</summary>
    [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
    public class OrganizationServiceProxy : ServiceProxy<IOrganizationService>, IOrganizationService
    {
        private string _xrmSdkAssemblyFileVersion;

        internal bool OfflinePlayback { get; set; }

        /// <summary>Gets or sets the ID of the user for whom SDK calls are made on behalf of.</summary>
        /// <returns>Type: Returns_Guid.The ID of the user for whom SDK calls are made on behalf of.</returns>
        public Guid CallerId { get; set; }

        internal int LanguageCodeOverride { get; set; }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_String.</returns>
        public string SyncOperationType { get; set; }

        internal string ClientAppName { get; set; }

        internal string ClientAppVersion { get; set; }

        /// <summary>Gets or sets the version of the client.</summary>
        /// <returns>Type: Returns_String.The version of the client.</returns>
        public string SdkClientVersion { get; set; }

        internal OrganizationServiceProxy()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a organization service URI, home realm URI, and client and device credentials.</summary>
        /// <param name="deviceCredentials">Type: Returns_ClientCredentials. The Windows Live ID device credentials.</param>
        /// <param name="homeRealmUri">Type: Returns_URI. This parameter is set to a non-null value when a second ADFS instance is configured as an identity provider to the ADFS instance that pn_CRM_2011 has been configured with for claims authentication. The parameter value is the URI of the WS-Trust metadata endpoint of the second ADFS instance.</param>
        /// <param name="uri">Type: Returns_URI. The URI of the organization service.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          Uri uri,
          Uri homeRealmUri,
          ClientCredentials clientCredentials,
          ClientCredentials deviceCredentials)
          : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and a security token response.</summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service configuration.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*public OrganizationServiceProxy(
          IServiceConfiguration<IOrganizationService> serviceConfiguration,
          SecurityTokenResponse securityTokenResponse)
          : base(serviceConfiguration, securityTokenResponse)
        {
        }*/

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and client credentials.</summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service configuration.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          IServiceConfiguration<IOrganizationService> serviceConfiguration,
          ClientCredentials clientCredentials)
          : base(serviceConfiguration, clientCredentials)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service management and a security token response.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service management.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*public OrganizationServiceProxy(
          IServiceManagement<IOrganizationService> serviceManagement,
          SecurityTokenResponse securityTokenResponse)
          : this(serviceManagement as IServiceConfiguration<IOrganizationService>, securityTokenResponse)
        {
        }*/

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and client credentials.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service management.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          IServiceManagement<IOrganizationService> serviceManagement,
          ClientCredentials clientCredentials)
          : this(serviceManagement as IServiceConfiguration<IOrganizationService>, clientCredentials)
        {
        }

        /// <summary>Enables support for the early-bound entity types.</summary>
        public void EnableProxyTypes()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, "orgConfig");
            serviceConfiguration.EnableProxyTypes();
        }

        /// <summary>Enables support for the early-bound entity types exposed in a specified assembly.</summary>
        /// <param name="assembly">Type: Returns_Assembly. An assembly containing early-bound entity types.</param>
        public void EnableProxyTypes(Assembly assembly)
        {
            ClientExceptionHelper.ThrowIfNull((object)assembly, nameof(assembly));
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, "orgConfig");
            serviceConfiguration.EnableProxyTypes(assembly);
        }

        [SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
        [SuppressMessage("Microsoft.Security", "CA2143:TransparentMethodsShouldNotDemandFxCopRule")]
        //[PermissionSet(SecurityAction.Demand, Unrestricted = true)]
        internal string GetXrmSdkAssemblyFileVersion()
        {
            if (string.IsNullOrEmpty(this._xrmSdkAssemblyFileVersion))
            {
                string[] strArray = new string[1]
                {
          "Microsoft.Xrm.Sdk.dll"
                };
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (string str in strArray)
                {
                    foreach (Assembly assembly in assemblies)
                    {
                        if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase))
                            this._xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    }
                }
            }
            return this._xrmSdkAssemblyFileVersion;
        }

        private Task<Guid> CreateCoreWithContextAsync(Entity entity, CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
                return this.ServiceChannel.Channel.CreateAsync(entity, cancellationToken);
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_GuidThe ID of the created entity.</returns>
        protected internal virtual async Task<Guid> CreateCoreAsync(Entity entity, CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    return await CreateCoreWithContextAsync(entity, cancellationToken);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return Guid.Empty;
        }

        private Task<Entity> RetrieveCoreWithContextAsync(
            string entityName,
            Guid id,
            ColumnSet columnSet,
            CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
                return this.ServiceChannel.Channel.RetrieveAsync(entityName, id, columnSet, cancellationToken);
        }

        /// <summary>internal</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.</returns>
        protected internal virtual async Task<Entity> RetrieveCoreAsync(
          string entityName,
          Guid id,
          ColumnSet columnSet,
          CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    return await RetrieveCoreWithContextAsync(entityName, id, columnSet, cancellationToken);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (Entity)null;
        }

        private Task UpdateCoreWithContextAsync(Entity entity, CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
            {
                return this.ServiceChannel.Channel.UpdateAsync(entity, cancellationToken);
            }
        }

        /// <summary>internal</summary>
        protected virtual async Task UpdateCoreAsync(Entity entity, CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    await UpdateCoreWithContextAsync(entity, cancellationToken);
                    break;
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        private Task DeleteCoreWithContext(string entityName, Guid id, CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
            {
                return this.ServiceChannel.Channel.DeleteAsync(entityName, id, cancellationToken);
            }
        }

        /// <summary>internal</summary>
        protected internal virtual async Task DeleteCoreAsync(string entityName, Guid id, CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    await DeleteCoreWithContext(entityName, id, cancellationToken);
                    break;
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        private Task<OrganizationResponse> ExecuteCoreWithContextAsync(
            OrganizationRequest request, CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
                return this.ServiceChannel.Channel.ExecuteAsync(request, cancellationToken);
        }

        /// <summary>internal</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>.</returns>
        protected internal virtual async Task<OrganizationResponse> ExecuteCoreAsync(
          OrganizationRequest request, CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    return await ExecuteCoreWithContextAsync(request, cancellationToken);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (OrganizationResponse)null;
        }

        private Task AssociateCoreWithContextAsync(
            string entityName,
            Guid entityId,
            Relationship relationship,
            EntityReferenceCollection relatedEntities,
            CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
            {
                return this.ServiceChannel.Channel.AssociateAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
            }
        }

        /// <summary>internal</summary>
        protected internal virtual async Task AssociateCoreAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    await AssociateCoreWithContextAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
                    break;
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        private Task DisassociateCoreWithContextAsync(
            string entityName,
            Guid entityId,
            Relationship relationship,
            EntityReferenceCollection relatedEntities,
            CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
            {
                return this.ServiceChannel.Channel.DisassociateAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
            }
        }

        /// <summary>internal</summary>
        protected internal virtual async Task DisassociateCoreAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    await DisassociateCoreWithContextAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
                    break;
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        private Task<EntityCollection> RetrieveMultipleCoreWithContextAsync(QueryBase query, CancellationToken cancellationToken)
        {
            using (new OrganizationServiceContextInitializer(this))
            {
                return this.ServiceChannel.Channel.RetrieveMultipleAsync(query, cancellationToken);
            }
        }

        /// <summary>internal</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>.</returns>
        protected internal async virtual Task<EntityCollection> RetrieveMultipleCoreAsync(QueryBase query, CancellationToken cancellationToken)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    cancellationToken.Register(() =>
                    {
                        this.ServiceChannel.Abort();
                    });

                    return await RetrieveMultipleCoreWithContextAsync(query, cancellationToken);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch(Exception aa)
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (EntityCollection)null;
        }

        /// <summary>Creates a record.</summary>
        /// <returns>Type: Returns_GuidThe ID of the created entity.</returns>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that contains the properties to set in the newly created record.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            return this.CreateCoreAsync(entity, cancellationToken);
        }

        /// <summary>Retrieves a record.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.The requested entity.</returns>
        /// <param name="id">Type: Returns_Guid. The ID of the record you want to retrieve.</param>
        /// <param name="columnSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>. A query that specifies the set of columns, or attributes, to retrieve.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            return this.RetrieveCoreAsync(entityName, id, columnSet, cancellationToken);
        }

        /// <summary>Updates an existing record.</summary>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that has one or more properties set to be updated in the record.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            return this.UpdateCoreAsync(entity, cancellationToken);
        }

        /// <summary>Deletes a record.</summary>
        /// <param name="id">Type: Returns_Guid. The ID of the record of the record to delete.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken)
        {
            return this.DeleteCoreAsync(entityName, id, cancellationToken);
        }

        /// <summary>Executes a message in the form of a request, and returns a response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>. You must cast the return value of this method to the specific instance of the response that corresponds to the Request parameter.</returns>
        /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. An instance of a request class that defines the action to be performed.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task<OrganizationResponse> ExecuteAsync(OrganizationRequest request, CancellationToken cancellationToken)
        {
            return this.ExecuteCoreAsync(request, cancellationToken);
        }

        /// <summary>Creates a link between records.</summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. A collection of entity references (references to records) to be associated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to create the link.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. The ID of the record to which the related records will be associated.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task AssociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            return this.AssociateCoreAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
        }

        /// <summary>Deletes a link between records. </summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. A collection of entity references (references to records) to be disassociated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to remove the link.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. The ID of the record from which the related records will be disassociated.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task DisassociateAsync(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities,
          CancellationToken cancellationToken)
        {
            return this.DisassociateCoreAsync(entityName, entityId, relationship, relatedEntities, cancellationToken);
        }

        /// <summary>Retrieves a collection of records.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>.A collection of entity records.</returns>
        /// <param name="query">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>. A query that determines the set of records to retrieve.</param>
        /// <param name="cancellationToken">Type: <see cref="T:System.Threading.CancellationToken"></see>. A token propagates notification that operations should be canceled.</param>
        public Task<EntityCollection> RetrieveMultipleAsync(QueryBase query, CancellationToken cancellationToken)
        {
            return this.RetrieveMultipleCoreAsync(query, cancellationToken);
        }
    }
}
