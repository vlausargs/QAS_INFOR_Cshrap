//PROJECT NAME: MG.MGCore
//CLASS NAME: IInitSessionContext.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IInitSessionContext
    {
        (int? ReturnCode, Guid? SessionID) InitSessionContextSp(string ContextName,
        Guid? SessionID,
        string Site = null);
    }
}

