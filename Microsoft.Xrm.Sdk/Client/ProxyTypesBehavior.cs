﻿using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Enables early-bound entity types on a service proxy.</summary>
    public sealed class ProxyTypesBehavior : IEndpointBehavior
    {
        private readonly object _lockObject = new object();
        private Assembly _proxyTypesAssembly;

        /// <summary>Initializes a new instance of the ProxyTypesBehavior class.</summary>
        public ProxyTypesBehavior()
        {
        }

        /// <summary>Initializes a new instance of the ProxyTypesBehavior class using an assembly containing proxy types generated by the CrmSvcUtil utility.</summary>
        /// <param name="proxyTypesAssembly">Type: Returns_Assembly. An assembly containing proxy types.</param>
        public ProxyTypesBehavior(Assembly proxyTypesAssembly)
        {
            this._proxyTypesAssembly = proxyTypesAssembly;
        }

        void IEndpointBehavior.AddBindingParameters(
          ServiceEndpoint serviceEndpoint,
          BindingParameterCollection bindingParameters)
        {
        }

        void IEndpointBehavior.ApplyClientBehavior(
          ServiceEndpoint serviceEndpoint,
          ClientRuntime behavior)
        {
            foreach (OperationDescription operation in (Collection<OperationDescription>)serviceEndpoint.Contract.Operations)
                this.UpdateFormatterBehavior(operation);
        }

        void IEndpointBehavior.ApplyDispatchBehavior(
          ServiceEndpoint serviceEndpoint,
          EndpointDispatcher endpointDispatcher)
        {
        }

        void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
        {
        }

        private void UpdateFormatterBehavior(OperationDescription operationDescription)
        {
            lock (this._lockObject)
            {
                DataContractSerializerOperationBehavior operationBehavior1 = operationDescription.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationBehavior1 != null)
                {
                    operationBehavior1.DataContractResolver = //new DataContractResolver
                        new KnownTypesResolver();
                    //operationBehavior1.DataContractSurrogate = (IDataContractSurrogate)new ProxySerializationSurrogate(this._proxyTypesAssembly);
                }
                else
                {
                    DataContractSerializerOperationBehavior operationBehavior2 = new DataContractSerializerOperationBehavior(operationDescription);
                    operationDescription.Behaviors.Add((IOperationBehavior)operationBehavior2);
                }
            }
        }
    }
}