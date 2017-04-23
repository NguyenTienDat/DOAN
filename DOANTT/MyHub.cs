using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace DOANTT
{
    [HubName("myChatHub")]
    public class MyHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void send(string message)
        {
            Clients.All.addMessage(message);
        }

    }
}