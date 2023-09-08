using CSI.Data.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Logistics.Customer
{
    public interface IHome_VchPayBuildPoFilterCondition
    {
        IParameterizedCommand GetPoFilterWhereClause(DateTime? CutoffDate, string SiteGroup, string filterInPlaceWhereClause);
    }
}
