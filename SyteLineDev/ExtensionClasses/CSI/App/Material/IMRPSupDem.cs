using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Material
{
    public interface IMRPSupDem
    {
        ICollectionLoadResponse MRPSupDemFn(int? DetailDisplay=0, int? UseFullyTransactedOrders=0, int? PExcludePLNs=0);
    }
}
