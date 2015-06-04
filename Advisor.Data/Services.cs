using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Data
{
    public static class Services
    {
        public static /*IServiceFactory*/ServiceLocator Factory { get; set; }
        static Services()
        {
            Services.Factory = new ServiceLocator();
        }
    }
}
