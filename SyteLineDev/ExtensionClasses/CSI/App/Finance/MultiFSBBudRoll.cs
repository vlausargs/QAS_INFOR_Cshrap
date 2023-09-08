//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBBudRoll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBBudRoll
    {
        int MultiFSBBudRollSp(FSBNameType FSBName,
                              ChartTypeType pAssetChart,
                              ChartTypeType pLiabilityChart,
                              ChartTypeType pOwnersEquityChart,
                              ChartTypeType pRevenueChart,
                              ChartTypeType pExpenseChart,
                              FiscalYearType pFromFiscalYear,
                              FiscalYearType pToFiscalYear,
                              StringType pBudPlan,
                              AcctType pBegAcct,
                              AcctType pEndAcct,
                              UnitCode1Type pBegAcctUnit1,
                              UnitCode1Type pEndAcctUnit1,
                              UnitCode2Type pBegAcctUnit2,
                              UnitCode2Type pEndAcctUnit2,
                              UnitCode3Type pBegAcctUnit3,
                              UnitCode3Type pEndAcctUnit3,
                              UnitCode4Type pBegAcctUnit4,
                              UnitCode4Type pEndAcctUnit4,
                              ref InfobarType rInfobar);
    }

    public class MultiFSBBudRoll : IMultiFSBBudRoll
    {
        readonly IApplicationDB appDB;

        public MultiFSBBudRoll(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBBudRollSp(FSBNameType FSBName,
                                     ChartTypeType pAssetChart,
                                     ChartTypeType pLiabilityChart,
                                     ChartTypeType pOwnersEquityChart,
                                     ChartTypeType pRevenueChart,
                                     ChartTypeType pExpenseChart,
                                     FiscalYearType pFromFiscalYear,
                                     FiscalYearType pToFiscalYear,
                                     StringType pBudPlan,
                                     AcctType pBegAcct,
                                     AcctType pEndAcct,
                                     UnitCode1Type pBegAcctUnit1,
                                     UnitCode1Type pEndAcctUnit1,
                                     UnitCode2Type pBegAcctUnit2,
                                     UnitCode2Type pEndAcctUnit2,
                                     UnitCode3Type pBegAcctUnit3,
                                     UnitCode3Type pEndAcctUnit3,
                                     UnitCode4Type pBegAcctUnit4,
                                     UnitCode4Type pEndAcctUnit4,
                                     ref InfobarType rInfobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBBudRollSp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pAssetChart", pAssetChart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pLiabilityChart", pLiabilityChart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pOwnersEquityChart", pOwnersEquityChart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pRevenueChart", pRevenueChart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pExpenseChart", pExpenseChart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pFromFiscalYear", pFromFiscalYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pToFiscalYear", pToFiscalYear, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBudPlan", pBudPlan, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBegAcct", pBegAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcct", pEndAcct, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBegAcctUnit1", pBegAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcctUnit1", pEndAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBegAcctUnit2", pBegAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcctUnit2", pEndAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBegAcctUnit3", pBegAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcctUnit3", pEndAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBegAcctUnit4", pBegAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pEndAcctUnit4", pEndAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rInfobar", rInfobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}