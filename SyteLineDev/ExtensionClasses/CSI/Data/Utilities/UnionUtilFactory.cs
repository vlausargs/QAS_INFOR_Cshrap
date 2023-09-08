using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.Utilities
{
    public class UnionUtilFactory : IUnionUtilFactory
    {
        public IUnionUtil Create(UnionType unionType = UnionType.UnionAll, string orderBy = null)
        {
            return new UnionUtil(unionType, orderBy);
        }
    }
}
