using GreeterProtos;
using Grpc.Core;

namespace GrpcService.Services
{
    public class GreeterServiceImpl : GreetingService.GreetingServiceBase
    {
        public override Task<HelloResponse> Greeting(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Message: {request.Name}");
            return Task.FromResult(new HelloResponse { Greeting = "Hello " + request.Name });
        }
    }
}
