using GreeterProtos;
using Grpc.Core;

namespace GreeterClient
{
    class Program
    {
        const string DefaultHost = "localhost";
        const int Port = 5011;

        public static void Main(string[] args)
        {
            RunAsync(args).Wait();
        }

        private static async Task RunAsync1(string[] args)
        {
            var host = args.Length == 1 ? args[0] : DefaultHost;
            var channelTarget = $"{host}:{Port}";

            Console.WriteLine($"Target: {channelTarget}");

            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);

            try
            {
                var client = new GreetingService.GreetingServiceClient(channel);

                var request = new HelloRequest
                {
                    Name = "Mete - on C#",
                    Age = 34,
                    Sentiment = Sentiment.Happy
                };

                Console.WriteLine("GreeterClient sending request");
                var response = await client.GreetingAsync(request);

                Console.WriteLine("GreeterClient received response: " + response.Greeting);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }

        private static async Task RunAsync(string[] args)
        {
            var host = args.Length == 1 ? args[0] : DefaultHost;
            var channelTarget = $"{host}:{Port}";

            Console.WriteLine($"Target: {channelTarget}");

            var channel = new Channel(channelTarget, ChannelCredentials.Insecure);

            try
            {
                var client = new GreetingService.GreetingServiceClient(channel);

                var request = new HelloRequest
                {
                    Name = "Mete - on C#",
                    Age = 34,
                    Sentiment = Sentiment.Happy
                };

                Console.WriteLine("GreeterClient sending request");
                var response = await client.GreetingAsync(request);

                Console.WriteLine("GreeterClient received response: " + response.Greeting);
            }
            finally
            {
                await channel.ShutdownAsync();
            }
        }
    }
}