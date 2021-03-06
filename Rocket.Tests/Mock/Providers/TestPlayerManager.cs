﻿using Rocket.API.DependencyInjection;
using Rocket.API.Drawing;
using Rocket.API.Player;
using Rocket.API.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rocket.Tests.Mock.Providers
{
    public class TestPlayerManager : IPlayerManager
    {
        public TestPlayerManager(IDependencyContainer container)
        {
            Container = container;
        }

        public IDependencyContainer Container { get; }

        public IEnumerable<IPlayer> Players => new List<IPlayer> { new TestPlayer(Container, this) };

        public IEnumerable<IUser> OnlineUsers => Players.Select(c => c.User);

        public bool Kick(IPlayer user, IUser kickedBy = null, string reason = null) => false;

        public bool Ban(IUser user, IUser bannedBy = null, string reason = null, TimeSpan? timeSpan = null)
            => false;

        public bool Unban(IUser user, IUser unbannedBy = null)
            => false;

        public void SendMessage(IUser sender, IPlayer receiver, string message, Color? color = null, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public void Broadcast(IUser sender, string message, Color? color = null, params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public IUser GetUser(string id, IdentityProvider provider = IdentityProvider.Builtin)
        {
            return GetPlayer(id)?.User;
        }

        public void Broadcast(IUser sender, IEnumerable<IPlayer> receivers, string message, Color? color = null,
                              params object[] arguments)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetOnlinePlayer(string nameOrId)
        {
            return Players.FirstOrDefault(c => c.User.Id.Equals(nameOrId, StringComparison.OrdinalIgnoreCase)
                || c.User.DisplayName.Equals(nameOrId, StringComparison.OrdinalIgnoreCase) || c.User.UserName.Equals(nameOrId, StringComparison.OrdinalIgnoreCase));
        }

        public IPlayer GetOnlinePlayerByName(string name) => GetOnlinePlayer(name);

        public IPlayer GetOnlinePlayerById(string id) => GetOnlinePlayer(id);

        public bool TryGetOnlinePlayer(string nameOrId, out IPlayer output)
            => throw new NotImplementedException();

        public bool TryGetOnlinePlayerById(string uniqueID, out IPlayer output)
            => throw new NotImplementedException();

        public bool TryGetOnlinePlayerByName(string displayName, out IPlayer output)
            => throw new NotImplementedException();

        public IPlayer GetPlayer(string id) => GetOnlinePlayer(id);

        public IPlayer GetPlayerByDisplayName(string name)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetPlayerByUserName(string name)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetPlayerById(string id)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayer(string nameOrId, out IPlayer output)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayerById(string id, out IPlayer output)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayerByDisplayName(string name, out IPlayer output)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayerByUserName(string name, out IPlayer output)
        {
            throw new NotImplementedException();
        }

        public IPlayer GetPlayerByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool TryGetPlayerByName(string name, out IPlayer output)
        {
            throw new NotImplementedException();
        }

        public string ServiceName => "TestPlayers";
    }
}