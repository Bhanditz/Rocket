﻿namespace Rocket.Core.Plugins.NuGet
{
    public class Repository
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Enabled { get; set; }
        public string ApiKey { get; set; }
        public string Type { get; set; }
    }
}