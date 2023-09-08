//PROJECT NAME: CSIFinance
//CLASS NAME: ChartBpSavePrep.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chart
{
    public interface IChartBpSavePrep
    {
        int ChartBpSavePrepSp(FlagNyType PNewRecord,
                              AcctType pChartBpAcct,
                              UnitCode1Type pChartBpAcctUnit1,
                              UnitCode2Type pChartBpAcctUnit2,
                              UnitCode3Type pChartBpAcctUnit3,
                              UnitCode4Type pChartBpAcctUnit4,
                              FiscalYearType pChartBpFiscalYear,
                              ref InfobarType Infobar);
    }

    public class ChartBpSavePrep : IChartBpSavePrep
    {
        readonly IApplicationDB appDB;

        public ChartBpSavePrep(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ChartBpSavePrepSp(FlagNyType PNewRecord,
                                     AcctType pChartBpAcct,
                                     UnitCode1Type pChartBpAcctUnit1,
                                     UnitCode2Type pChartBpAcctUnit2,
                                     UnitCode3Type pChartBpAcctUnit3,
                                     UnitCode4Type pChartBpAcctUnit4,
                                     FiscalYearType pChartBpFiscalYear,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ChartBpSavePrepSp";

                appDB.AddCommandParameter(cmd, "PNewRecord", PNewRecord, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpAcct", pChartBpAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpAcctUnit1", pChartBpAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpAcctUnit2", pChartBpAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpAcctUnit3", pChartBpAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpAcctUnit4", pChartBpAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pChartBpFiscalYear", pChartBpFiscalYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}