using Microsoft.Xrm.Sdk.NtlmHttp;
using System;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk.Client;

public class HttpMessageHandlerBehavior : IEndpointBehavior
{
    private NetworkCredential _credential;

    public void SetCredentials(NetworkCredential credential) => _credential = credential;

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
        // Snapshot credentials for this factory. Creating another factory must
        // neither modify a running handler nor change its authenticated identity.
        var credential = _credential;
        bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(handler =>
        {
            handler.AutomaticDecompression = DecompressionMethods.GZip;
            return new NtlmHttpMessageHandler(handler) { NetworkCredential = credential };
        }));
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }
    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }
    public void Validate(ServiceEndpoint endpoint) { }
}