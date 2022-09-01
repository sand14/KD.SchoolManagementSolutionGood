using System;

namespace KD.WPF.Client.APIClient
{
    public class ApplicationConfiguration : IClientApplicationConfiguration
    {
        public string ServerAddress => "https://localhost:7144";

        public string AppUri => "AppUri";

        public string ClientId => "ClientId";


      
    }
}
