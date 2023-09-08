//PROJECT NAME: MG.MGCore
//CLASS NAME: IExecuteDynamicSQL.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
    public interface IExecuteDynamicSQL
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar,
        int? ImpactedRowCount) ExecuteDynamicSQLSp(int? NeedGetMoreRows = 0,
        string Infobar = null,
        int? ImpactedRowCount = 0);
    }
}

