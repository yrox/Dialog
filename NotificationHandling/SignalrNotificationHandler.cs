﻿using System;
using DTOs;
using Microsoft.AspNet.SignalR;
using NotificationHandling.Hubs;
using NotificationHandling.Interfaces;

namespace NotificationHandling
{
    public class SignalrNotificationHandler : INotificationHandler
    {
        private readonly IHubContext _hubContext = GlobalHost.ConnectionManager.GetHubContext<NotifyingНub>();
               

        public void SendMessage(MessageDTO message)
        {
            _hubContext.Clients.All.MessageRecived(message);
        }

        public void AddContact(ContactDTO contact)
        {
            throw new NotImplementedException();
        }

        public string ThrowCaptcha(string captchaUrl, long sid)
        {
            return _hubContext.Clients.All.CaptchaNeeded(captchaUrl);
        }

        public string ThrowCode()
        {
            return _hubContext.Clients.All.CodeNeeded();
        }

        public void UpdateAccount(AccountDTO account)
        {
            throw new NotImplementedException();
        }
    }
}