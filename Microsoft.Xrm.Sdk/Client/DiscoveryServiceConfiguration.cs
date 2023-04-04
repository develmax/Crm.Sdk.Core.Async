﻿using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Net.Http;
//using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;
//using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Xrm.Sdk.Client
{
    internal sealed class DiscoveryServiceConfiguration : IServiceConfiguration<IDiscoveryService>, /*IWebAuthentication<IDiscoveryService>,*/ IServiceManagement<IDiscoveryService>/*, IEndpointSwitch*/
    {
        private readonly ServiceConfiguration<IDiscoveryService> service;

        private DiscoveryServiceConfiguration()
        {
        }

        internal DiscoveryServiceConfiguration(Uri serviceUri)
        {
            this.service = new ServiceConfiguration<IDiscoveryService>(serviceUri, false);
        }

        public ServiceEndpoint CurrentServiceEndpoint
        {
            get
            {
                return this.service.CurrentServiceEndpoint;
            }
            set
            {
                this.service.CurrentServiceEndpoint = value;
            }
        }

        /*public IssuerEndpoint CurrentIssuer
        {
            get
            {
                return this.service.CurrentIssuer;
            }
            set
            {
                this.service.CurrentIssuer = value;
            }
        }*/

        public AuthenticationProviderType AuthenticationType
        {
            get
            {
                return this.service.AuthenticationType;
            }
        }

        public ServiceEndpointDictionary ServiceEndpoints
        {
            get
            {
                return this.service.ServiceEndpoints;
            }
        }

        /*public IssuerEndpointDictionary IssuerEndpoints
        {
            get
            {
                return this.service.IssuerEndpoints;
            }
        }*/

        /*public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints
        {
            get
            {
                return this.service.CrossRealmIssuerEndpoints;
            }
        }*/

        public ChannelFactory<IDiscoveryService> CreateChannelFactory()
        {
            return this.service.CreateChannelFactory(ClientAuthenticationType.Kerberos);
        }

        public ChannelFactory<IDiscoveryService> CreateChannelFactory(
          ClientAuthenticationType clientAuthenticationType)
        {
            return this.service.CreateChannelFactory(clientAuthenticationType);
        }

        public ChannelFactory<IDiscoveryService> CreateChannelFactory(
          ClientCredentials clientCredentials)
        {
            return this.service.CreateChannelFactory(clientCredentials);
        }

        /*public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials)
        {
            return this.service.Authenticate(clientCredentials);
        }

        public SecurityTokenResponse Authenticate(SecurityToken securityToken)
        {
            return this.service.Authenticate(securityToken);
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
          ClientCredentials clientCredentials,
          string appliesTo,
          Uri crossRealmSts)
        {
            return this.service.AuthenticateCrossRealm(clientCredentials, appliesTo, crossRealmSts);
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
          SecurityToken securityToken,
          string appliesTo,
          Uri crossRealmSts)
        {
            return this.service.AuthenticateCrossRealm(securityToken, appliesTo, crossRealmSts);
        }

        public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceSecurityTokenResponse)
        {
            return this.service.Authenticate(clientCredentials, deviceSecurityTokenResponse);
        }

        public SecurityTokenResponse AuthenticateDevice(
          ClientCredentials clientCredentials)
        {
            return this.service.AuthenticateDevice(clientCredentials);
        }*/

        public PolicyConfiguration PolicyConfiguration
        {
            get
            {
                return this.service.PolicyConfiguration;
            }
        }

        /*public IdentityProvider GetIdentityProvider(string userPrincipalName)
        {
            return this.service.GetIdentityProvider(userPrincipalName);
        }*/

        /*public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          Uri uri,
          string keyType)
        {
            return this.service.Authenticate(clientCredentials, uri, keyType);
        }

        public SecurityTokenResponse Authenticate(
          SecurityToken securityToken,
          Uri uri,
          string keyType)
        {
            return this.service.Authenticate(securityToken, uri, keyType);
        }*/

        public AuthenticationCredentials Authenticate(
          AuthenticationCredentials authenticationCredentials)
        {
            return this.service.Authenticate(authenticationCredentials);
        }

        /*public bool EndpointAutoSwitchEnabled
        {
            get
            {
                return this.service.EndpointAutoSwitchEnabled;
            }
            set
            {
                this.service.EndpointAutoSwitchEnabled = value;
            }
        }*/

        /*public Uri AlternateEndpoint
        {
            get
            {
                return this.service.AlternateEndpoint;
            }
        }

        public Uri PrimaryEndpoint
        {
            get
            {
                return this.service.PrimaryEndpoint;
            }
        }*/

        /*public void SwitchEndpoint()
        {
            this.service.SwitchEndpoint();
        }

        public bool HandleEndpointSwitch()
        {
            return this.service.HandleEndpointSwitch();
        }

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
        {
            add
            {
                this.service.EndpointSwitched += value;
            }
            remove
            {
                this.service.EndpointSwitched -= value;
            }
        }*/

        /*public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
        {
            add
            {
                this.service.EndpointSwitchRequired += value;
            }
            remove
            {
                this.service.EndpointSwitchRequired -= value;
            }
        }*/

        /*public bool IsPrimaryEndpoint
        {
            get
            {
                return this.service.IsPrimaryEndpoint;
            }
        }*/

        /*public bool CanSwitch(Uri currentUri)
        {
            return this.service.CanSwitch(currentUri);
        }*/
    }
}