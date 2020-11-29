using HomeApp.WebApi.Contracts;

namespace HomeApp.WebApi.Settings
{
    public class AuthSettings: IJsonSettings
    {
        public string Authority { get; set; }
        public string Audience { get; set; }

        public string SectionName => nameof(AuthSettings);
    }
}
