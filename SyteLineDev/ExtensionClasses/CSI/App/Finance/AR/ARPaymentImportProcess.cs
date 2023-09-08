//PROJECT NAME: CSICustomer
//CLASS NAME: ARPaymentImportProcess.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARPaymentImportProcess
    {
        int ARPaymentImportProcessSp(ARImportBatchIdType BatchID,
                                     ARImportHeaderNumType HeaderNum,
                                     ref InfobarType Infobar);
    }

    public class ARPaymentImportProcess : IARPaymentImportProcess
    {
        readonly IApplicationDB appDB;

        public ARPaymentImportProcess(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARPaymentImportProcessSp(ARImportBatchIdType BatchID,
                                            ARImportHeaderNumType HeaderNum,
                                            ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARPaymentImportProcessSp";

                appDB.AddCommandParameter(cmd, "BatchID", BatchID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HeaderNum", HeaderNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
