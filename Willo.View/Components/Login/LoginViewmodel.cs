using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Willo.Logic;
using Willo.Logic.Components.Login;
using Willo.Logic.Infrastructure;
using Willo.View.Components.Navigation;
using Willo.View.Components.Navigation.Messaging;
using Willo.View.Components.UserMessaging.Messaging;
using Willo.View.Utilities;
using Windows.UI.Xaml.Controls;

namespace Willo.View.Components.Login
{
    public class LoginViewmodel
    {
        private IMessageBroker messageBroker;
        private Settings settings;
        public string Url { get; private set; } = "";

        public LoginViewmodel(IMessageBroker messageBroker, Settings settings)
        {
            this.messageBroker = messageBroker;
            this.settings = settings;
        }

        public async Task Initialize()
        {
            if (settings.AuthorizationToken != null)
            {
                await messageBroker.Command(new AuthorizeCommand(settings.AuthorizationToken.Value));
                await messageBroker.Command(new NavigateRegionCommand(NavigationRegions.Content, new BoardOverview.BoardOverview()));
            }

            var queryResult = await messageBroker.Query(new AuthorizationUrlQuery());
            Url = queryResult.Result;
        }

        public async Task SetAuthorizationTokenFromHtml(string html)
        {
            var tokenRegex = new Regex("[0-9a-z]{64}", RegexOptions.IgnoreCase);
            var matches = tokenRegex.Matches(html);
            var tokens = new List<string>();
            foreach (Match match in matches)
            {
                var token = match.Value;
                var queryResult = await messageBroker.Query(new IsAuthorizationTokenQuery(token));
                var isAuthorizationToken = queryResult.Result;
                if (isAuthorizationToken)
                    tokens.Add(token);
            }
            if (tokens.Count > 0)
            {
                var result = await messageBroker.Command(new AuthorizeCommand(tokens.First()));
                var errors = result.Errors;
                if (errors.Count() == 0)
                {
                    settings.AuthorizationToken = tokens.First();
                    await messageBroker.Command(new NavigateRegionCommand(NavigationRegions.Content, new BoardOverview.BoardOverview()));
                }
            }
        }
    }
}
