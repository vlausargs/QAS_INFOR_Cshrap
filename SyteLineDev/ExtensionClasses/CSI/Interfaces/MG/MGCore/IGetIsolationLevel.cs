//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetIsolationLevel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetIsolationLevel
    {
        string GetIsolationLevelFn(string Taskname);
    }
}

