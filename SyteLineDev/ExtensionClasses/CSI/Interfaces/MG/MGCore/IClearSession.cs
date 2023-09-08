//PROJECT NAME: MG.MGCore
//CLASS NAME: IClearSession.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IClearSession
    {
        (int? ReturnCode, string Infobar) ClearSessionSp(Guid? ConnectionID,
        string UserName,
        string Infobar);
    }
}

