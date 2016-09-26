using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;
using Willo.Logic.Infrastructure;

namespace Willo.View.Components.Navigation.Messaging
{
    public class NavigateRegionCommandHandler : CommandHandlerBase<NavigateRegionCommand>
    {
        private NavigationManager navigationManager;

        public NavigateRegionCommandHandler(NavigationManager navigationManager)
        {
            this.navigationManager = navigationManager;
        }

        public override Task<IEnumerable<IError>> Handle(NavigateRegionCommand command)
        {
            navigationManager.NavigateRegion(command.NavigationRegionName, command.Content);
            return Task.FromResult(Enumerable.Empty<IError>());
        }
    }
}
