// See https://aka.ms/new-console-template for more information

using Grpc.Net.Client;
using gRPCStarterKit.Client;

var channel = GrpcChannel.ForAddress("http://localhost:5238");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
    new HelloRequest { Name = "Thomas" });
Console.WriteLine("Greeting: " + reply.Message);