﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Willo.Logic;
using Willo.Logic.Login;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Login
{
    public class LoginViewmodel
    {
        private MessageBroker messageBroker;
        public string Url { get; private set; }

        public event EventHandler NavigationToBoardOverviewRequested;

        public LoginViewmodel(MessageBroker messageBroker)
        {
            this.messageBroker = messageBroker;
        }

        public async Task Initialize()
        {
            Url = await messageBroker.Query(new AuthorizationUrlQuery());
        }

        public async Task SetHtml(string html)
        {
            var tokenRegex = new Regex("[0-9a-z]{64}", RegexOptions.IgnoreCase);
            var matches = tokenRegex.Matches(html);
            var tokens = new List<string>();
            foreach (Match match in matches)
            {
                var token = match.Value;
                if (await messageBroker.Query(new IsAuthorizationTokenQuery(token)))
                    tokens.Add(token);
            }
            if (tokens.Count > 0)
            {
                var errors = await messageBroker.Command(new AuthorizeCommand(tokens.First()));
                if (errors.Count() == 0)
                    NavigationToBoardOverviewRequested(null, null);
            }
        }
    }
}
