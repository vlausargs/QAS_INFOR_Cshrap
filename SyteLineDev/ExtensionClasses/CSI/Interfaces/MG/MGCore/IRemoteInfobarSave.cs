//PROJECT NAME: MG.MGCore
//CLASS NAME: IRemoteInfobarSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IRemoteInfobarSave
    {
        int? RemoteInfobarSaveSp(string Infobar);
    }
}

