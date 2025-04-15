using System.Text.Json;
using System.Text.Json.Serialization;
using Ai.Hgb.Common.Entities;
using Ai.Hgb.Dat.Communication;
using Ai.Hgb.Dat.Configuration;

namespace Ai.Hgb.Application.Prosumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Ai.Hgb.Application.Prosumer\n");

            var parameters = JsonSerializer.Deserialize<Parameters>(args[0]);
            var routingTable = JsonSerializer.Deserialize<RoutingTable>(args[1]);

            // setup socket and converter
            var address = new HostAddress(parameters.ApplicationParametersNetworking.HostName, parameters.ApplicationParametersNetworking.HostPort);
            var converter = new JsonPayloadConverter();
            var cts = new CancellationTokenSource();
            ISocket socket = null;

            try
            {
                socket = new MqttSocket(parameters.Name, parameters.Name, address, converter, connect: true);

                // <add publish, subscribe, request, response actions here>

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Disconnect();
            }
        }
    }

    public class Parameters : IApplicationParametersBase, IApplicationParametersNetworking
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("applicationParametersBase")]
        public ApplicationParametersBase ApplicationParametersBase { get; set; }

        [JsonPropertyName("applicationParametersNetworking")]
        public ApplicationParametersNetworking ApplicationParametersNetworking { get; set; }

        // <add nodetype properties here>
    }
}
