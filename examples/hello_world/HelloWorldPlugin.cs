﻿using System.Collections.Generic;
using Rocket.API.DependencyInjection;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace Rocket.Examples.HelloWorldPlugin
{
    public class HelloWorldPlugin : Plugin
    {
        public HelloWorldPlugin(IDependencyContainer container) : base("HelloWorldPlugin", container)
        {
            RegisterCommandsFromObject(this);
        }

        public override object DefaultConfiguration => new
        {
            MyConfigField = "MyFieldValue",
            NestedSection = new
            {
                NestedConfigField = "MyNestedFieldValue"
            }
        };

        public override Dictionary<string, string> DefaultTranslations => new Dictionary<string, string>
        {
            {"some_translatable_message", "This is some translatable / replaceable text!"}
        };

        protected override void OnActivate(bool isFromReload)
        {
            Logger.LogInformation("Hello world!");
        }

        protected override void OnDeactivate()
        {
            Logger.LogInformation("Good bye!");
        }
    }
}