using System.ServiceModel.Description;
using System.Threading;

namespace Microsoft.Xrm.Sdk.Client
{
    // Keep the public cancellation-aware interface. Cancellation is a client-only
    // argument and must not become an extra member of CRM's SOAP message.
    internal static class LocalCancellationContract
    {
        internal static void Configure(ContractDescription contract)
        {
            foreach (var operation in contract.Operations)
            {
                foreach (var message in operation.Messages)
                {
                    if (message.Direction != MessageDirection.Input) continue;
                    for (var i = message.Body.Parts.Count - 1; i >= 0; i--)
                    {
                        if (message.Body.Parts[i].Type == typeof(CancellationToken))
                            message.Body.Parts.RemoveAt(i);
                    }
                }
            }
        }
    }
}
