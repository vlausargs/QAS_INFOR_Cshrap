//PROJECT NAME: MG.MGCore
//CLASS NAME: ICloseSession.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface ICloseSession
    {
        int? CloseSessionSp(Guid? ID);
    }
}

