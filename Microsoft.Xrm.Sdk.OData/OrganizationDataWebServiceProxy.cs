using Microsoft.Xrm.Sdk.OData.NtlmHttp;
using Microsoft.Xrm.Sdk.OData.Query;
using Microsoft.Xrm.Sdk.OData.Utility;
using Newtonsoft.Json;      // Used in the REST methods
using Newtonsoft.Json.Linq; // Used in the REST methods
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Microsoft.Xrm.Sdk.OData
{
    public class OrganizationDataWebServiceProxy
    {
        #region class members

        private const string webEndpoint = "/XRMServices/2011/Organization.svc/web";
        private const string restEndpoint = "/XRMServices/2011/OrganizationData.svc/";

        public OrganizationDataWebServiceProxy(string serviceUrl)
        {
            ServiceUrl = serviceUrl;
        }

        public OrganizationDataWebServiceProxy(string serviceUrl, NetworkCredential credential)
        {
            ServiceUrl = serviceUrl;
            Credential = credential;
        }

        public string ServiceUrl { get; set; }
        public string AccessToken { get; set; } // can be private, but not sure if user want to access it.
        public Guid CallerId { get; set; }
        public int Timeout { get; set; }
        public NetworkCredential Credential { get; set; }
        public bool UseProxy { get; set; }


        static protected IEnumerable<TypeInfo> types;   // change types to be protected so it can be used in early bound after a SOAP call

        #endregion class members

        #region Soap Methods

        // Provide same methods as IOrganizationService with same parameter and types
        // so that developer can use this class without confusion.

        /// <summary>
        /// Creates a link between records.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">The ID of the record to which the related records are associated.</param>
        /// <param name="relationship">The name of the relationship to be used to create the link.</param>
        /// <param name="relatedEntities">A collection of entity references (references to records) to be associated.</param>
        public async Task AssociateAsync(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Associate";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Associate>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:entityId>" + entityId.ToString() + "</d:entityId>");
                content.Append(Util.ObjectToXml(relationship, "d:relationship", true));
                content.Append(Util.ObjectToXml(relatedEntities, "d:relatedEntities", true));
                content.Append("</d:Associate>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //do nothing
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Creates a record.
        /// </summary>
        /// <param name="entity">An entity instance that contains the properties to set in the newly created record.</param>
        /// <returns>The ID of the newly created record.</returns>
        public async Task<Guid> CreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Create";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Create>");
                content.Append(Util.ObjectToXml(entity, "d:entity", true));
                content.Append("</d:Create>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                Guid createdRecordId = Guid.Empty;
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Obtain Guid values from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var result in xdoc.Descendants(Util.ns.d + "CreateResponse"))
                    {
                        createdRecordId = Util.LoadFromXml<Guid>(result);
                    }
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }

                return createdRecordId;
            }
        }
        /// <summary>
        /// Deletes a record.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to delete.</param>
        public async Task DeleteAsync(string entityName, Guid id, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Delete";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Delete>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:id>" + id.ToString() + "</d:id>");
                content.Append("</d:Delete>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Do nothing as it returns void.
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }
        /// <summary>
        /// Deletes a link between records.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="entityId">The ID of the record from which the related records are disassociated.</param>
        /// <param name="relationship">The name of the relationship to be used to remove the link.</param>
        /// <param name="relatedEntities">A collection of entity references (references to records) to be disassociated.</param>
        public async Task DisassociateAsync(string entityName, Guid entityId, Relationship relationship,
            EntityReferenceCollection relatedEntities, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Disassociate";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Disassociate>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:entityId>" + entityId.ToString() + "</d:entityId>");
                content.Append(Util.ObjectToXml(relationship, "d:relationship", true));
                content.Append(Util.ObjectToXml(relatedEntities, "d:relatedEntities", true));
                content.Append("</d:Disassociate>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    //do nothing
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }


            }
        }
        /// <summary>
        /// Executes a message in the form of a request, and returns a response.
        /// </summary>
        /// <param name="request">A request instance that defines the action to be performed.</param>
        /// <returns>The response from the request. You must cast the return value of this method to 
        /// the specific instance of the response that corresponds to the Request parameter.</returns>
        public async Task<OrganizationResponse> ExecuteAsync(OrganizationRequest request, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Execute";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Execute>");
                content.Append(request.GetRequestBody());
                content.Append("</d:Execute>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // 1. Request contains instance of its corresponding Response.
                    // 2. Response has override StoreResult method to extract data
                    // from result if necessary.
                    request.ResponseType.StoreResult(httpResponse);
                    return request.ResponseType;
                }
                else
                {
                    // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
                    // May need to redo this when applying new version of this file
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (fault != null)
                    {
                        throw fault;
                    }
                    else
                    {
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                    }
                }
            }
        }
        /// <summary>
        /// Retrieves a record.
        /// </summary>
        /// <param name="entityName">The logical name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to retrieve.</param>
        /// <param name="columnSet">A query that specifies the set of columns, or attributes, to retrieve.</param>
        /// <returns>The requested entity. If EnableProxyTypes called, returns early bound type.</returns>
        public async Task<Entity> RetrieveAsync(string entityName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Retrieve";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Retrieve>");
                content.Append("<d:entityName>" + entityName + "</d:entityName>");
                content.Append("<d:id>" + id.ToString() + "</d:id>");
                content.Append(Util.ObjectToXml(columnSet, "d:columnSet", true));
                content.Append("</d:Retrieve>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                Entity Entity = new Entity();

                // Chech the returned code
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Extract Entity from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var result in xdoc.Descendants(Util.ns.d + "RetrieveResult"))
                    {
                        Entity = Entity.LoadFromXml(result);
                    }
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }

                // If Entity if not casted yet, then try to cast to early-bound
                if (Entity.GetType().Equals(typeof(Entity)))
                    Entity = ConvertToEarlyBound(Entity);

                return Entity;
            }
        }
        /// <summary>
        /// Retrieves a collection of records.
        /// </summary>
        /// <param name="query">A query that determines the set of records to retrieve.</param>
        /// <returns>The collection of entities returned from the query. If EnableProxyTypes called, returns early bound type.</returns>
        public async Task<EntityCollection> RetrieveMultipleAsync(QueryBase query, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/RetrieveMultiple";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:RetrieveMultiple>");
                content.Append(Util.ObjectToXml(query, "d:query"));
                content.Append("</d:RetrieveMultiple>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                EntityCollection entityCollection = null;

                // Check the returned code
                if (httpResponse.IsSuccessStatusCode)
                {
                    // Extract EntityCollection from result.
                    XDocument xdoc = XDocument.Parse(httpResponse.Content.ReadAsStringAsync().Result, LoadOptions.None);
                    foreach (var results in xdoc.Descendants(Util.ns.d + "RetrieveMultipleResult"))
                    {
                        entityCollection = EntityCollection.LoadFromXml(results);
                    }
                }
                else
                {
                    // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
                    // May need to redo this when applying new version of this file
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (fault != null)
                    {
                        throw fault;
                    }
                    else
                    {
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                    }
                }

                return entityCollection;
            }
        }
        /// <summary>
        /// Updates an existing record.
        /// </summary>
        /// <param name="entity">An entity instance that has one or more properties set to be updated in the record.</param>
        public async Task UpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string SOAPAction = "http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/Update";

                StringBuilder content = new StringBuilder();
                content.Append(GetEnvelopeHeader());
                content.Append("<s:Body>");
                content.Append("<d:Update>");
                content.Append(Util.ObjectToXml(entity, "d:entity", true));
                content.Append("</d:Update>");
                content.Append("</s:Body>");
                content.Append("</s:Envelope>");

                // Send the request asychronously and wait for the response.
                HttpResponseMessage httpResponse;
                httpResponse = await SendRequestAsync(httpClient, SOAPAction, content.ToString(), cancellationToken);

                if (httpResponse.IsSuccessStatusCode)
                {
                    // Do nothing as it returns void.
                }
                else
                {
                    OrganizationServiceFault fault = RestoreError(httpResponse);
                    if (!String.IsNullOrEmpty(fault.Message))
                        throw fault;
                    else
                        throw new Exception(httpResponse.Content.ReadAsStringAsync().Result);
                }
            }
        }

        #endregion methods

        #region Rest Methods

        /// <summary>
        /// create record
        /// </summary>
        /// <param name="entity">record to create</param>
        /// <returns></returns>
        public async Task<Guid?> RestCreateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                DataContractJsonSerializer jasonSerializer = new DataContractJsonSerializer(entity.GetType());
                string json;
                using (MemoryStream ms = new MemoryStream())
                {
                    jasonSerializer.WriteObject(ms, entity);
                    json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                }
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                string ODataAction = entity.GetType().GetRuntimeField("SchemaName").ToString() + "Set";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Use PostAsync to Post data.
                HttpResponseMessage response = await httpClient.PostAsync(ServiceUrl + restEndpoint + ODataAction, content, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    Entity result;
                    // Deserialize response to JToken 
                    byte[] resultbytes = Encoding.UTF8.GetBytes(response.Content.ReadAsStringAsync().Result);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        result = (Entity)jasonSerializer.ReadObject(ms);
                    }
                    return result.Id;
                }
                else
                    throw new Exception("REST Create failed.");
            }
        }

        /// <summary>
        /// Deletes a record.
        /// </summary>
        /// <param name="schemaName">The Schema name of the entity that is specified in the entityId parameter.</param>
        /// <param name="id">The ID of the record that you want to delete.</param>
        public async Task RestDeleteAsync(string schemaName, Guid id, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                string ODataAction = schemaName + "Set(guid'" + id + "')";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Use DeleteAsync to Post data.
                HttpResponseMessage response = await httpClient.DeleteAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                if (!response.IsSuccessStatusCode)
                    throw new Exception("REST Delete failed.");
            }
        }

        /// <summary>
        /// Retrieve a record
        /// </summary>
        /// <param name="schemaName">Entity SchemaName.</param>
        /// <param name="id">id of record to be retireved</param>
        /// <param name="columnSet">retrieved columns</param>
        /// <returns></returns>
        public async Task<Entity> RestRetrieveAsync(string schemaName, Guid id, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                StringBuilder select = new StringBuilder();
                foreach (string column in columnSet.Columns)
                {
                    select.Append("," + column);
                }

                // The URL for the OData organization web service.
                string ODataAction = schemaName + "Set(guid'" + id + "')?$select=" + select.ToString().Remove(0, 1) + "";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.            
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Wait for the web service response.
                HttpResponseMessage response = await httpClient.GetAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    // Check type.
                    TypeInfo currentType;
                    if (types == null)
                        throw new Exception("Early-bound types must be enabled for a REST Retrieve.");
                    else
                    {
                        currentType = types.Where(x => x.Name.ToLower() == schemaName.ToLower()).FirstOrDefault();
                        if (currentType == null)
                            throw new Exception("Early-bound types must be enabled for a REST Retrieve.");
                    }
                    // Deserialize response to JToken 
                    JToken jtoken = JObject.Parse(response.Content.ReadAsStringAsync().Result)["d"];
                    return (Entity)JsonConvert.DeserializeObject(jtoken.ToString(), currentType.AsType());
                }
                else
                    throw new Exception("REST Retrieve failed.");
            }
        }

        /// <summary>
        /// Need to consider how to implement this. Let developer create URL or implement convert method form QueryBase to URL?
        /// For now, just let user pass schemaName and ColumnSet.
        /// </summary>
        /// <param name="schemaName"></param>
        /// <param name="columnSet"></param>
        /// <returns></returns>
        public async Task<EntityCollection> RestRetrieveMultipleAsync(string schemaName, ColumnSet columnSet, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                StringBuilder select = new StringBuilder();
                foreach (string column in columnSet.Columns)
                {
                    select.Append("," + column);
                }

                // The URL for the OData organization web service.
                string ODataAction = schemaName + "Set?$select=" + select.ToString().Remove(0, 1) + "";

                if (!string.IsNullOrEmpty(AccessToken))
                {
                    // Build and send the HTTP request.
                    httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", AccessToken);
                }

                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Wait for the web service response.
                HttpResponseMessage response = await httpClient.GetAsync(ServiceUrl + restEndpoint + ODataAction, cancellationToken);

                // Check the response result.
                if (response.IsSuccessStatusCode)
                {
                    EntityCollection results = new EntityCollection();
                    results.EntityName = schemaName.ToLower();

                    // Check type.
                    TypeInfo currentType;
                    if (types == null)
                        throw new Exception("Early-bound types must be enabled for a REST RetrieveMultiple.");
                    else
                    {
                        currentType = types.Where(x => x.Name.ToLower() == schemaName.ToLower()).FirstOrDefault();
                        if (currentType == null)
                            throw new Exception("Early-bound types must be enabled for a REST RetrieveMultiple.");
                    }

                    // Deserialize response to JToken IList
                    IList<JToken> jTokens = JObject.Parse(response.Content.ReadAsStringAsync().Result)["d"]["results"].Children().ToList();
                    foreach (JToken jToken in jTokens)
                    {
                        // Deserialize result to Type T
                        results.Entities.Add((Entity)JsonConvert.DeserializeObject(jToken.ToString(), currentType.AsType()));
                    }
                    results.TotalRecordCount = jTokens.Count();
                    return results;
                }
                else
                    throw new Exception("REST RetrieveMultiple failed.");
            }
        }

        /// <summary>
        /// Update a record
        /// </summary>
        /// <param name="entity">record to update</param>
        /// <returns></returns>
        public async Task RestUpdateAsync(Entity entity, CancellationToken cancellationToken)
        {
            // Create HttpClient with Compression enabled.
            using (HttpClient httpClient = CreateHttpClient())
            {
                DataContractJsonSerializer jasonSerializer = new DataContractJsonSerializer(entity.GetType());
                MemoryStream ms = new MemoryStream();
                jasonSerializer.WriteObject(ms, entity);
                string json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);
                StringContent content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                // The URL for the OData organization web service.
                string ODataAction = entity.GetType().GetRuntimeField("SchemaName").ToString() + "Set(guid'" + entity.Id + "')";

                // Build and send the HTTP request.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                // Specify MERGE to update record
                httpClient.DefaultRequestHeaders.Add("X-HTTP-Method", "MERGE");

                // Use PostAsync to Post data.
                HttpResponseMessage response = await httpClient.PostAsync(ServiceUrl + restEndpoint + ODataAction, content, cancellationToken);

                // Check the response result.
                if (!response.IsSuccessStatusCode)
                    throw new Exception("REST Update failed.");
            }
        }
        #endregion

        #region helpercode

        private HttpClient CreateHttpClient()
        {
            HttpMessageHandler httpMessageHandler = Credential != null
                ? new NtlmHttpMessageHandler(new HttpClientHandler( ) { AutomaticDecompression = System.Net.DecompressionMethods.GZip, UseProxy = UseProxy}) {NetworkCredential = Credential}
                : new HttpClientHandler() { AutomaticDecompression = System.Net.DecompressionMethods.GZip, UseProxy = UseProxy };

            return new HttpClient(httpMessageHandler);
        }

        // To make this project Xamarin compatible, you need to comment out this method.
        public void EnableProxyTypes()
        {
            List<TypeInfo> typeList = new List<TypeInfo>();
            // Obtain folder of executing application.
            /*var folder = Package.Current.InstalledLocation;
            foreach (var file in await folder.GetFilesAsync())
            {
                // not only .dll but .exe also contains types.
                if (file.FileType == ".dll" || file.FileType == ".exe")
                {
                    var assemblyName = new AssemblyName(file.DisplayName);
                    var assembly = Assembly.Load(assemblyName);
                    foreach (TypeInfo type in assembly.DefinedTypes)
                    {
                        // Store only CRM Entities.
                        if (type.BaseType == typeof(Entity))
                            typeList.Add(type);
                    }
                }
            }*/
            types = typeList.ToArray();
        }

        /// <summary>
        /// Create HTTPRequest and returns the HTTPRequestMessage.
        /// </summary>
        /// <param name="httpClient">httpClient instance.</param>
        /// <param name="SOAPAction">Action for the endpoint, like Execute, Retrieve, etc.</param>
        /// <param name="content">Request Body</param>
        /// <returns>HTTPRequest</returns>
        private async Task<HttpResponseMessage> SendRequestAsync(HttpClient httpClient, string SOAPAction, string content, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(AccessToken))
            {
                // Set the HTTP authorization header using the access token.
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (Timeout > 0)
                httpClient.Timeout = new TimeSpan(0, 0, 0, Timeout, 0);
            // Finish setting up the HTTP request.
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, ServiceUrl + webEndpoint);
            req.Headers.Add("SOAPAction", SOAPAction);
            req.Method = HttpMethod.Post;
            req.Content = new StringContent(content);
            req.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("text/xml; charset=utf-8");

            // Send the request asychronously and wait for the response.            
            return await httpClient.SendAsync(req, cancellationToken);
        }

        /// <summary>
        /// Create Envelope for SOAP request.
        /// </summary>
        /// <returns>SOAP Envelope with namespaces.</returns>
        /// <summary>
        /// Enable Early Bound by storing all Types in the application.
        /// </summary>
        /// <returns>SOAP Envelope with namespaces.</returns>
        ///       
        private string GetEnvelopeHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<s:Envelope xmlns:s='http://schemas.xmlsoap.org/soap/envelope/' xmlns:a='http://schemas.microsoft.com/xrm/2011/Contracts' xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns:b='http://schemas.datacontract.org/2004/07/System.Collections.Generic' xmlns:c='http://www.w3.org/2001/XMLSchema' xmlns:d='http://schemas.microsoft.com/xrm/2011/Contracts/Services' xmlns:e='http://schemas.microsoft.com/2003/10/Serialization/' xmlns:f='http://schemas.microsoft.com/2003/10/Serialization/Arrays' xmlns:g='http://schemas.microsoft.com/crm/2011/Contracts' xmlns:h='http://schemas.microsoft.com/xrm/2011/Metadata' xmlns:j='http://schemas.microsoft.com/xrm/2011/Metadata/Query' xmlns:k='http://schemas.microsoft.com/xrm/2013/Metadata' xmlns:l='http://schemas.microsoft.com/xrm/2012/Contracts'>");
            sb.Append("<s:Header>");
            if (this.CallerId != null && this.CallerId != Guid.Empty)
                sb.Append("<a:CallerId>" + this.CallerId.ToString() + "</a:CallerId>");
            sb.Append("<a:SdkClientVersion>6.0</a:SdkClientVersion>");
            sb.Append("</s:Header>");
            return sb.ToString();
        }
        private OrganizationServiceFault RestoreError(HttpResponseMessage httpResponse)
        {
            // This is the fix for issue that if the response is not an XML, this will throw XML parse error, and hide the original error
            // May need to redo this when applying new version of this file
            try
            {
                string content = httpResponse.Content.ReadAsStringAsync().Result;
                if(String.IsNullOrEmpty(content))
                {
                    OrganizationServiceFault serviceFault = new OrganizationServiceFault();
                    serviceFault.ErrorCode = (int)httpResponse.StatusCode;
                    return serviceFault;
                }
                else
                {
                    XDocument xdoc = XDocument.Parse(content, LoadOptions.None);
                    return OrganizationServiceFault.LoadFromXml(xdoc.Descendants(Util.ns.a + "OrganizationServiceFault").First());
                }
            }
            catch
            {
                return null;
            }
        }
        static internal Entity ConvertToEarlyBound(Entity entity)
        {
            if (types == null)
                return entity;
            TypeInfo currentType = types.Where(x => x.Name.ToLower() == entity.LogicalName).FirstOrDefault();
            if (currentType == null)
                return entity;
            else
                // Then convert it by using Entity.ToEntity<T> method.
                return (Entity)typeof(Entity).GetRuntimeMethod("ToEntity", new Type[] { }).
                    MakeGenericMethod(currentType.AsType()).Invoke(entity, null);
        }

        #endregion helpercode
    }
}