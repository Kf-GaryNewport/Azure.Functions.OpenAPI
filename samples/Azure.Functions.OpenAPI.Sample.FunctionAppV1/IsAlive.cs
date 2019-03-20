using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace Azure.Functions.OpenAPI.Sample.FunctionAppV1
{
    [Description("Is Alive Contract")]
    public class IsAliveContract
    {
        [Display(Description = "Version of Application")]
        public string Version { get; set; }

        [Display(Description = "TimeStamp")]
        public DateTimeOffset Timestamp { get; set; }

        [Display(Description = "Is Alive Value")]
        public bool IsAlive { get; set; }

        [Display(Description = "Region name")]
        public string RegionName { get; set; }
    }

    public static class IsAlive
    {
        public static readonly string ApplicationVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        const string IsAliveFunctionName = "IsAlive";
        [FunctionName(IsAliveFunctionName)]
        [ResponseType(typeof(IsAliveContract))]
        public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, WebRequestMethods.Http.Get)]HttpRequestMessage req, TraceWriter log)
        {

            var result = new IsAliveContract
            {
                IsAlive = true,
                Timestamp = DateTimeOffset.UtcNow,
                Version = ApplicationVersion,
                RegionName = Environment.GetEnvironmentVariable("REGION_NAME")
            };

            return req.CreateResponse(HttpStatusCode.OK, result, "application/json");
        }
    }
}
