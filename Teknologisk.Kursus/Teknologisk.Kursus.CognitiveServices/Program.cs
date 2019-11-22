using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Teknologisk.Kursus.CognitiveServices
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("https://computervision-jdk.cognitiveservices.azure.com/");
            string endpoint = Environment.GetEnvironmentVariable("70a9ae837f984e09b875d1c0ed0d0d7d");

            ComputerVisionClient client =
                new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey))
                    { Endpoint = endpoint };

            ImageAnalysis results = await client.AnalyzeImageAsync("https://i.imgur.com/ECDOG02.png");

            Console.ReadLine(); 
        }
    }
}
