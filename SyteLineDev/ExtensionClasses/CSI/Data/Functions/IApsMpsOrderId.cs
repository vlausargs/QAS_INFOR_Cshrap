//PROJECT NAME: Data
//CLASS NAME: IApsMpsOrderId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
    public interface IApsMpsOrderId
    {
        string ApsMpsOrderIdFn(
            string PItem,
            string PRefNum);
    }
}

