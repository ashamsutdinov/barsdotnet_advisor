using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Data
{
    public interface IServiceFactory
    {
        TService Get<TService>();
    }
}
