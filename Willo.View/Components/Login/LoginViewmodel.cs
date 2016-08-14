using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async void WebContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            string token = await sender.InvokeScriptAsync("eval", new string[] { "[].map.call(document.getElementsByTagName('pre'), function(node){ return node.innerText; }).join('||');" });
            token = token.Trim();
            if (await messageBroker.Query(new IsAuthorizationTokenQuery(token)))
            {
                await messageBroker.Command(new AuthorizeCommand(token));
                NavigationToBoardOverviewRequested(null, null);
            }
        }
    }
}
