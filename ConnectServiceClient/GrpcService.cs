using System.Threading.Tasks;

namespace ConnectServiceClient;

using Grpc.Net.Client;
using ReactiveUI;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

public class GrpcService
{
    private readonly Greeter.GreeterClient _client;
    
    public GrpcService()
    {
        var channel = GrpcChannel.ForAddress("https://localhost:50052");
        _client = new Greeter.GreeterClient(channel);
    }
    
    public async Task<string> SayHello(string name)
    {
        var reply = await _client.SayHelloAsync(new HelloRequest { Name = name });
        return reply.Message;
    }
}