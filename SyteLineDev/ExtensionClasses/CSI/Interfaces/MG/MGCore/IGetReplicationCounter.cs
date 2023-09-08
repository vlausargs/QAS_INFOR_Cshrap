//PROJECT NAME: MG.MGCore
//CLASS NAME: IGetReplicationCounter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IGetReplicationCounter
    {
        (int? ReturnCode, decimal? OperationCounter,
        string Infobar) GetReplicationCounterSp(string Site,
        decimal? OperationCounter,
        string Infobar);
    }
}

