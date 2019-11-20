using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Teknologisk.Kursus.Functions
{
    public static class ShutDownVMs
    {
        [FunctionName("ShutDownTheVMs")]
        public static void Run([TimerTrigger("0 30 16 * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            //get acces through  Home -> Default Directory -App registrations -> Register an application

            var clientId = "";
            var tenantId = "";
            var clientSecret = "";

            var credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(clientId, clientSecret, tenantId, AzureEnvironment.AzureGlobalCloud);

            var azure = Azure.Configure().Authenticate(azureCredentials: credentials).WithDefaultSubscription();

            
            var VMs = azure.VirtualMachines;
            foreach(var VM in VMs.List())
            {
                log.LogInformation("Shutting down VMs " + VM.Name);
                VM.PowerOff();
                log.LogInformation("VM " + VM.Name + " has been stopped and have status: " + VM.PowerState);
            }
        }
    }
}
