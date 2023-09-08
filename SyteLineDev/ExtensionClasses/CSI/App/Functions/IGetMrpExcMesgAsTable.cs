using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Functions
{
    public interface IGetMrpExcMesgAsTable
    {
        ICollectionLoadResponse GetMrpExcMesgAsTableFn(string item, string MrpOrderType, string ApsOrder, int? MrpOrderLine, int MrpOrderRelease, Guid? RowPointer);
    }
}
