using FakeGladiatus.Application.Entities;
using FakeGladiatus.Application.Entities.DbEntities;
using FakeGladiatus.Application.Repositories;
using FakeGladiatus.Application.Services;
using FakeGladiatus.Application.Services.Interfaaces;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeGladiatus
{
    public class NotificationHub : Hub
    {
   

        public async Task GetNotification(string userId)
        {
            await Clients.All.SendAsync("GetNotification", Convert.ToInt32(userId));
        }
    }
}
