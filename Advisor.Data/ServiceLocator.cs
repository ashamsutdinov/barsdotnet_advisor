using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Advisor.Data
{
    public class ServiceLocator
        /*:IServiceFactory*/
    {
        private static readonly UnityContainer Container;

        static ServiceLocator()
        {
            Container = new UnityContainer();
            Container.LoadConfiguration();
        }

        public /*static*/ TService Get<TService>()
        {
            return Container.Resolve<TService>();
        }
    }
}