
namespace Qualysoft.Evaluation.Console
{
    using Newtonsoft.Json;
    using Qualysoft.Evaluation.Application;
    using Qualysoft.Evaluation.Data;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Console app
    /// </summary>
    /// <remarks>
    /// The second project would be a console application which sends a collection of serialized Request models via a HTTP POST request to the API.
    /// The address of the API should be configured in the App.config file.
    /// The console application should receive one input parameter from the command line which would be an INT which specifies the number of models
    /// </remarks>
    static class Program
    {
        const string ApiData = "/api/Data";
        const string mediaTypeJson = "application/json";
        
        static void Main(string[] args)
        {
            if (args == null ||
                args.Length < 2 ||
                !int.TryParse(args[0], out int requestsCount) ||
                !Enum.TryParse<EndpointType>(args[1], out EndpointType endpointType))
            {
                Usage();
            }
            else
            {
                try
                {
                    PostApiDataAsync(requestsCount, endpointType).Wait();
                }
                catch (Exception ex)
                {
                    Error(ex);
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.Read();
        }

        private static void Error(Exception ex)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ResetColor();
        }

        static void Usage()
        {
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Usage Qualysoft.Evaluation.Console [numberOfRequestDtos] [EndpointType]");
            Console.ResetColor();
        }

        static async Task PostApiDataAsync(int numberOfRequestDtos, EndpointType endpointType)
        {
            var enumerable = BogusDataGenerator.RequestDtos(numberOfRequestDtos);
            var dtos = new List<RequestModel>(enumerable).AsReadOnly();
            string json = JsonConvert.SerializeObject(dtos);
            var stringContent = new StringContent(json, Encoding.UTF8, mediaTypeJson);

            HttpClient apiClient = new HttpClient();
            var httpResponseMessage = await apiClient.PostAsync(Uri(endpointType), stringContent);
            Console.WriteLine(httpResponseMessage.StatusCode);
        }
        
        static string ProductionHttpUri() => ConfigurationManager.AppSettings["ProductionHttp"];

        static string ProductionHttpsUri() => ConfigurationManager.AppSettings["ProductionHttps"];

        static string DevelopmentHttpUri() => ConfigurationManager.AppSettings["DevelopmentHttp"];

        static string DevelopmentHttpsUri() => ConfigurationManager.AppSettings["DevelopmentHttps"];

        static string Uri(EndpointType endpointTypeEnum)
        {
            switch (endpointTypeEnum)
            {
                default:
                case EndpointType.ProdHttp: return $"{ProductionHttpUri()}{ApiData}";
                case EndpointType.ProdHttps: return $"{ProductionHttpsUri()}{ApiData}";
                case EndpointType.DevHttp: return $"{DevelopmentHttpUri()}{ApiData}";
                case EndpointType.DevHttps: return $"{DevelopmentHttpsUri()}{ApiData}";
            }
        }            
    }
}