using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Advisor.Dal.Domain;

namespace Advisor.Data
{
    public interface IRatingManager
    {
        Rating Add(int UserId, int ProductId, int Value);
        Rating Get(int AuthorId, int ProductId);
    }
}
