using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

namespace SignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press a key to start Listening...");
            Console.ReadKey();
            string _myAccessToken = string.Empty;

            var connection = new HubConnectionBuilder()
                .WithUrl($"http://localhost:8006/notificationhub"//, options =>
                //{
                //    options.AccessTokenProvider = () => Task.FromResult<string>(_myAccessToken);
                //}
                )
                .Build();

            connection.On<string>("ReceiveMessage", (message) => { Console.WriteLine(message); });

            //connection.InvokeAsync<string>("SendPrivateMessage", "HELLO World ").ContinueWith(task => {
            //    if (task.IsFaulted)
            //    {
            //        Console.WriteLine("There was an error calling send: {0}",
            //                          task.Exception.GetBaseException());
            //    }
            //    else
            //    {
            //        Console.WriteLine(task.Result);
            //    }
            //});

            connection.StartAsync()
                .GetAwaiter()
                .GetResult();

            Console.WriteLine("Listening. Press a key to Quit");
            Console.ReadKey();
            

        }
    }
}
