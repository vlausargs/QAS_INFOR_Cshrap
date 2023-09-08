//PROJECT NAME: MG.MGCore
//CLASS NAME: IInitSession.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IInitSession
    {
        int? InitSessionSp(Guid? ID,
        string UserName,
        string Site = null);
    }
}

