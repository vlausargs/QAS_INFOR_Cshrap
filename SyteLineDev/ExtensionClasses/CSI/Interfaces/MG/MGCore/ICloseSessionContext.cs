//PROJECT NAME: MG.MGCore
//CLASS NAME: ICloseSessionContext.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICloseSessionContext
    {
        int? CloseSessionContextSp(Guid? SessionID);
    }
}

