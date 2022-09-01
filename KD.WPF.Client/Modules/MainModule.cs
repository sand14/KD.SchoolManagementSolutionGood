using KD.WPF.Client.APIClient;
using KD.WPF.Client.APIClient.RestServices;
using KD.WPF.Client.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace KD.WPF.Client.Modules
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<StudentView>();
            containerRegistry.RegisterForNavigation<TeacherView>();
            containerRegistry.Register<IHttpClientFactory, HttpClientFactory>();
            containerRegistry.Register<IClientApplicationConfiguration, ApplicationConfiguration>();
            containerRegistry.Register<StudentRestService>();
        }
    }
}
