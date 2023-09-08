//PROJECT NAME: MG.MGCore
//CLASS NAME: IInitSessionContextWithUser.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IInitSessionContextWithUser
    {
        (int? ReturnCode, Guid? SessionID) InitSessionContextWithUserSp(string ContextName,
        string UserName,
        Guid? SessionID,
        string Site = null);
    }
}

