using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Builders
{
    interface IBuilder<ViewModel,DomainModel>
    {
        ViewModel Build(DomainModel dm);
    }
}
