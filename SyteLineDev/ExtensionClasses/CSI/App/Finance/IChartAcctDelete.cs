//PROJECT NAME: Finance
//CLASS NAME: IChartAcctDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface IChartAcctDelete
    {
        (int? ReturnCode,
        string Infobar) ChartAcctDeleteSp(
            int? pNewRecord = 0,
            string pChartAcct = null,
            string Infobar = null);
    }
}

