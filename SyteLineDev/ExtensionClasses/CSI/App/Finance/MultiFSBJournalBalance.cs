//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBJournalBalance.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface IMultiFSBJournalBalance
    {
        int MultiFSBJournalBalanceSp(FSBNameType FSBName,
                                     JournalIdType JournalId,
                                     ref AmtTotType BalDr,
                                     ref AmtTotType BalCr,
                                     ref AmtTotType RevDr,
                                     ref AmtTotType RevCr,
                                     ref InfobarType Infobar);
    }

    public class MultiFSBJournalBalance : IMultiFSBJournalBalance
    {
        readonly IApplicationDB appDB;

        public MultiFSBJournalBalance(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MultiFSBJournalBalanceSp(FSBNameType FSBName,
                                            JournalIdType JournalId,
                                            ref AmtTotType BalDr,
                                            ref AmtTotType BalCr,
                                            ref AmtTotType RevDr,
                                            ref AmtTotType RevCr,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MultiFSBJournalBalanceSp";

                appDB.AddCommandParameter(cmd, "FSBName", FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JournalId", JournalId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BalDr", BalDr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BalCr", BalCr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RevDr", RevDr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RevCr", RevCr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}