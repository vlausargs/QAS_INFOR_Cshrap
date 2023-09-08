//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcReValidateTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
    public interface IDcReValidateTransactions
    {
        int DcReValidateTransactionsSp(StringType Receiving,
                                       StringType Shipping,
                                       StringType MiscIssue,
                                       StringType Quantity,
                                       StringType Job,
                                       StringType Transfer,
                                       StringType Time,
                                       StringType Production,
                                       StringType JIT,
                                       StringType Work,
                                       ref InfobarType Infobar);
    }

    public class DcReValidateTransactions : IDcReValidateTransactions
    {
        readonly IApplicationDB appDB;

        public DcReValidateTransactions(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int DcReValidateTransactionsSp(StringType Receiving,
                                              StringType Shipping,
                                              StringType MiscIssue,
                                              StringType Quantity,
                                              StringType Job,
                                              StringType Transfer,
                                              StringType Time,
                                              StringType Production,
                                              StringType JIT,
                                              StringType Work,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DcReValidateTransactionsSp";

                appDB.AddCommandParameter(cmd, "Receiving", Receiving, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Shipping", Shipping, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MiscIssue", MiscIssue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Quantity", Quantity, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Transfer", Transfer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Time", Time, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Production", Production, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JIT", JIT, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Work", Work, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
