//PROJECT NAME: MG.MGCore
//CLASS NAME: IFireGenericNotify.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IFireGenericNotify
    {
        (int? ReturnCode, string Infobar) FireGenericNotifySp(string To,
        string Subject,
        string Category = null,
        string Body = null,
        string HTMLBody = null,
        string Infobar = null);
    }
}

