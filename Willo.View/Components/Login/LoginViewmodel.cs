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
        private LoginLogic logic;
        public string Url { get; private set;}
        
        public event EventHandler NavigationToBoardOverviewRequested;

        public LoginViewmodel(LoginLogic logic)
        {
            this.logic = logic;
        }

        public void Initialize()
        {
            Url = logic.GetAuthenticationUrl();
        }

        public async void WebContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            string token = await sender.InvokeScriptAsync("eval", new string[] { "[].map.call(document.getElementsByTagName('pre'), function(node){ return node.innerText; }).join('||');" });
            token = token.Trim();
            if (logic.IsAuthorizationToken(token))
            {
                logic.Authorize(token);
                NavigationToBoardOverviewRequested(null, null);
            }
        }
    }
}
