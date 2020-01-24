using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Net.Http;

namespace TestClient
{
   public class Program 
    {

        
        
        static void Main(string[] args)
        {
            var connection = new HubConnectionBuilder().WithUrl("http://192.168.10.33:6061/NotificationHub").Build();

            connection.StartAsync().Wait();
            connection.InvokeCoreAsync("CreateNotification", args : new[] {"2"});
            connection.On("GetNotification", (int userId) =>
             {
                 using var client = new HttpClient();
                 var result =  client.GetAsync("http://192.168.10.33:6060/api/notification/notifications");
                 Console.WriteLine(result.Status);
             });
        }
    }
}
