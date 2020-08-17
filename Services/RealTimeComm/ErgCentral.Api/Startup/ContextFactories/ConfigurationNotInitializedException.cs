using System;

namespace ErgCentral.Api.Startup.ContextFactories
{
    public class ConfigurationNotInitializedException : ApplicationException
    {
        public ConfigurationNotInitializedException(string msg) : base(msg)
        {
        }
    }
}