using System.Text.Json;
using System.Text.Json.Serialization;
using Ai.Hgb.Common.Entities;
using Ai.Hgb.Dat.Communication;
using Ai.Hgb.Dat.Configuration;
using Ai.Hgb.Application.ProCon.Common;

namespace Ai.Hgb.Application.ProCon.Consumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Ai.Hgb.Application.ProCon.Consumer\n");

            var parameters = JsonSerializer.Deserialize<Parameters>(args[0]);
            var routingTable = JsonSerializer.Deserialize<RoutingTable>(args[1]);

            // setup socket and converter
            var address = new HostAddress(parameters.ApplicationParametersNetworking.HostName, parameters.ApplicationParametersNetworking.HostPort);
            var converter = new JsonPayloadConverter();
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            ISocket socket = null;

            try
            {
                socket = new MqttSocket(parameters.Name, parameters.Name, address, converter, connect: true);

                #region publish
                var producerTasks = new Dictionary<string, Task>();
                var producerTasksFlat = producerTasks.Values.ToList();
                #endregion publish

                #region subscribe

                // TODO: move the following to the desired position
                // subscription port: docs
                foreach (var route in routingTable.Routes.Where(x => x.Sink.Id == parameters.Name && x.SinkPort.Type == PortType.Consumer && x.SinkPort.Id == "docs"))
                {
                    socket.Subscribe<Document>(route.SinkPort.Address, (msg, t) =>
                    {
                        // TODO: modify the following by your needs
                        var payload = (Document)msg.Content;
                        Console.WriteLine($"Received message: {payload.ToString()}");
                    }, token);
                }
                #endregion subscribe

                #region request
                var requestTasks = new Dictionary<string, Task>();
                var requestTasksFlat = requestTasks.Values.ToList();
                #endregion request

                #region respond
                #endregion respond


                // start publish and request actions
                producerTasksFlat.ForEach(x => x.Start());
                requestTasksFlat.ForEach(x => x.Start());

                // do something else ...

                // await publish and request actions
                await Task.WhenAll(producerTasksFlat);
                await Task.WhenAll(requestTasksFlat);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                socket.Unsubscribe();
                socket.Disconnect();
            }
        }
    }

    public class Parameters : IApplicationParametersBase, IApplicationParametersNetworking
    {
        [JsonPropertyName("applicationParametersBase")]
        public ApplicationParametersBase ApplicationParametersBase { get; set; }

        [JsonPropertyName("applicationParametersNetworking")]
        public ApplicationParametersNetworking ApplicationParametersNetworking { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("docCount")]
        public int DocCount { get; set; }
    }
}
