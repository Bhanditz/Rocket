﻿using System;
using System.Linq;
using Rocket.API.Commands;
using Rocket.API.DependencyInjection;
using Rocket.API.User;
using Rocket.Core.ServiceProxies;

namespace Rocket.Core.Commands
{
    public class ProxyCommandHandler : ServiceProxy<ICommandHandler>, ICommandHandler
    {
        public ProxyCommandHandler(IDependencyContainer container) : base(container) { }

        public bool HandleCommand(IUser user, string commandLine, string prefix)
        {
            GuardUser(user);

            foreach (ICommandHandler handler in ProxiedServices.Where(c => c.SupportsUser(user.GetType())))
                if (handler.HandleCommand(user, commandLine, prefix))
                    return true;

            return false;
        }

        public bool SupportsUser(Type user)
        {
            return ProxiedServices.Any(c => c.SupportsUser(user));
        }

        private void GuardUser(IUser user)
        {
            if (!SupportsUser(user.GetType()))
                throw new NotSupportedException(user.GetType().FullName + " is not supported!");
        }
    }
}