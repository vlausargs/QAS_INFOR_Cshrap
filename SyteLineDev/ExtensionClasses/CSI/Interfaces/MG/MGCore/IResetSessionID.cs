//PROJECT NAME: MG.MGCore
//CLASS NAME: IResetSessionID.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IResetSessionID
    {
        int? ResetSessionIDSp(Guid? ID);
    }
}

