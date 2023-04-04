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
    private readonly Func<HttpClientHandler, HttpMessageHandler> _httpMessageHandler;
    private NetworkCredential _credential;
    private NtlmHttpMessageHandler _handler;

    public HttpMessageHandlerBehavior()
    {
        // Here we prescribe how handler will be created.
        // Since it uses IHttpMessageHandlerFactory, this factory will manage the setup and lifetime of the handler, 
        // based on the configuration we provided with AddHttpClient(serviceName) 
        _httpMessageHandler = (clientHandler) =>
        {
            clientHandler.AutomaticDecompression = DecompressionMethods.GZip;

            var ntlmHttpMessageHandler = _handler = new NtlmHttpMessageHandler(clientHandler);

            if (_credential != null)
            {
                _handler.NetworkCredential = _credential;
            }

            return ntlmHttpMessageHandler;
        };
    }

    public void SetCredentials(NetworkCredential credential)
    {
        _credential = credential;

        if (_handler != null)
        {
            _handler.NetworkCredential = credential;
        }
    }

    //private Ne

    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
        // We need this line to add our HttpMessageHandler as HttpClientHandler.
        bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(handler =>  _httpMessageHandler(handler)));
    }

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime) { }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher) { }

    public void Validate(ServiceEndpoint endpoint) { }

}