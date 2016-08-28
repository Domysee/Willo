using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Willo.Logic;

namespace Willo.View.Components.Navigation.Messaging
{
    public class AddNavigationRegionCommandHandler : CommandHandlerBase<AddNavigationRegionCommand>
    {
        private NavigationCreator navigationCreator;
        private NavigationManager navigationManager;

        public AddNavigationRegionCommandHandler(NavigationCreator navigationCreator, NavigationManager navigationManager)
        {
            this.navigationCreator = navigationCreator;
            this.navigationManager = navigationManager;
        }

        public override Task<IEnumerable<IError>> Handle(AddNavigationRegionCommand command)
        {
            var navigator = navigationCreator.Create(command.Target);
            navigationManager.AddRegion(command.NavigationRegionName, navigator);
            return Task.FromResult(Enumerable.Empty<IError>());
        }
    }
}
