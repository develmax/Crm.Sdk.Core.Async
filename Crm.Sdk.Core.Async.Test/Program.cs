using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xrm.Sdk.OData;
using System;
using System.Net;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;

namespace Crm.Sdk.Core.Test
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                //WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultCredentials; //System.Net.CredentialCache.DefaultNetworkCredentials
                WebRequest.DefaultWebProxy = null;

                var _crmUrl = "https://crm.test.ru/";
                var _organizationName = "Org";

                var clientCredentials = new System.ServiceModel.Description.ClientCredentials();
                clientCredentials.Windows.ClientCredential.UserName = "crmuser03012";
                clientCredentials.Windows.ClientCredential.Password = "123QWEasd";
                
                var web = new OrganizationDataWebServiceProxy($"{_crmUrl}{_organizationName}", clientCredentials.Windows.ClientCredential);

                var q1 = new Microsoft.Xrm.Sdk.OData.Query.QueryExpression("role")
                {
                    ColumnSet = { Columns = { "name", "businessunitid", "roleid" } },
                    Orders =
                    {
                        new Microsoft.Xrm.Sdk.OData.Query.OrderExpression("name", Microsoft.Xrm.Sdk.OData.Query.OrderType.Ascending)
                    },
                    LinkEntities =
                    {
                        new Microsoft.Xrm.Sdk.OData.Query.LinkEntity
                        {
                            LinkFromEntityName = "role",
                            LinkFromAttributeName = "roleid",
                            LinkToEntityName = "systemuserroles",
                            LinkToAttributeName = "roleid",
                            JoinOperator = Microsoft.Xrm.Sdk.OData.Query.JoinOperator.Inner,
                            LinkEntities =
                            {
                                new Microsoft.Xrm.Sdk.OData.Query.LinkEntity
                                {
                                    LinkFromEntityName = "systemuserroles",
                                    LinkFromAttributeName = "systemuserid",
                                    LinkToEntityName = "systemuser",
                                    LinkToAttributeName = "systemuserid",
                                    JoinOperator = Microsoft.Xrm.Sdk.OData.Query.JoinOperator.Inner,
                                    LinkCriteria =
                                    {
                                        Filters =
                                        {
                                            new Microsoft.Xrm.Sdk.OData.Query.FilterExpression
                                            {
                                                FilterOperator = Microsoft.Xrm.Sdk.OData.Query.LogicalOperator.And,
                                                Conditions =
                                                {
                                                    new Microsoft.Xrm.Sdk.OData.Query.ConditionExpression("systemuserid",
                                                        Microsoft.Xrm.Sdk.OData.Query.ConditionOperator.EqualUserId)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                var result1 = await web.RetrieveMultipleAsync(q1, CancellationToken.None);
                
                //return result.Entities.Select(i => i.GetAttributeValue<string>("name"));
                foreach (var role in result1.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }

                var result11 = await web.RetrieveMultipleAsync(q1, CancellationToken.None);

                foreach (var role in result11.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }


                var config = Microsoft.Xrm.Sdk.Client.ServiceConfigurationFactory
                    .CreateConfiguration<Microsoft.Xrm.Sdk.IOrganizationService>(
                        new Uri($"{_crmUrl}{_organizationName}/XRMServices/2011/Organization.svc"));

                foreach (var endpoint in config.ServiceEndpoints)
                {
                    if (endpoint.Value.Binding is BasicHttpBinding binding)
                    {
                        binding.UseDefaultWebProxy = false;
                    }
                }
                var client = new Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy(config, clientCredentials);
                
                //client.CallerId = new Guid("5c073647-da06-e611-80f9-005056971789");

                var q = new Microsoft.Xrm.Sdk.Query.QueryExpression("role")
                {
                    ColumnSet = {Columns = {"name", "businessunitid", "roleid"}},
                    Orders =
                    {
                        new Microsoft.Xrm.Sdk.Query.OrderExpression("name", Microsoft.Xrm.Sdk.Query.OrderType.Ascending)
                    },
                    LinkEntities =
                    {
                        new Microsoft.Xrm.Sdk.Query.LinkEntity("role", "systemuserroles", "roleid", "roleid",
                            Microsoft.Xrm.Sdk.Query.JoinOperator.Inner)
                        {
                            LinkEntities =
                            {
                                new Microsoft.Xrm.Sdk.Query.LinkEntity("systemuserroles", "systemuser", "systemuserid",
                                    "systemuserid", Microsoft.Xrm.Sdk.Query.JoinOperator.Inner)
                                {
                                    LinkCriteria =
                                    {
                                        Filters =
                                        {
                                            new Microsoft.Xrm.Sdk.Query.FilterExpression(Microsoft.Xrm.Sdk.Query
                                                .LogicalOperator.And)
                                            {
                                                Conditions =
                                                {
                                                    new Microsoft.Xrm.Sdk.Query.ConditionExpression("systemuserid",
                                                        Microsoft.Xrm.Sdk.Query.ConditionOperator.EqualUserId)
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };

                var rq = new Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest()
                {
                    Query = q
                };

                /*var n = new Microsoft.Crm.Sdk.Messages.SetStateRequest
                {
                    EntityMoniker =
                        new Microsoft.Xrm.Sdk.EntityReference("lead", new Guid("c5dc1b6f-1712-e811-8229-005056977311")),
                    State = new Microsoft.Xrm.Sdk.OptionSetValue(0),
                    Status = new Microsoft.Xrm.Sdk.OptionSetValue(100000003)
                };

                var r = client.Execute(n);*/

                var result = await client.RetrieveMultipleAsync(q, CancellationToken.None);
                
                //return result.Entities.Select(i => i.GetAttributeValue<string>("name"));
                foreach (var role in result.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }
                var result2 = await client.RetrieveMultipleAsync(q, CancellationToken.None);

                foreach (var role in result.Entities)
                {
                    Console.WriteLine(role.GetAttributeValue<string>("name"));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine();
            Console.WriteLine("Press key");
            Console.ReadKey();
        }
    }
}
