﻿using Dialog.Busness.Notifications.Signalr;
using Microsoft.Owin;
using Owin;
//TODO move notif to web
[assembly: OwinStartup(typeof(Startup))]

namespace Dialog.Busness.Notifications.Signalr
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}