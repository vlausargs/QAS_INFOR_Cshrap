//PROJECT NAME: Finance
//CLASS NAME: IChartAcctGetIsControl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
    public interface IChartAcctGetIsControl
    {
            (int? ReturnCode,
            int? IsControl,
            string Infobar) 
        ChartAcctGetIsControlSP(
            string ChartAcct,
            int? IsControl,
            string Infobar);
    }
}

