using HomeApp.WebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeApp.WebApi.Providers
{
    public static class JsonSettingsProvider
    {
        public static IEnumerable<Type> GetSettings()
        {
            var type = typeof(IJsonSettings);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface);
            return types;
        }
    }
}
