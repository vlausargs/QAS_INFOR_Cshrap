//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSExpenseRecon.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSExpenseRecon
    {
        int SSSFSExpenseReconSp(StringType Mode,
                                FSPayTypeType PayType,
                                AmountType MiscCharges,
                                AmountType AmountDue,
                                VendNumType VendNum,
                                VendInvNumType InvNum,
                                DateType InvDate,
                                DateType DistDate,
                                FSReconBatchIdType BatchId,
                                ref InfobarType Infobar);
    }

    public class SSSFSExpenseRecon : ISSSFSExpenseRecon
    {
        readonly IApplicationDB appDB;

        public SSSFSExpenseRecon(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSExpenseReconSp(StringType Mode,
                                       FSPayTypeType PayType,
                                       AmountType MiscCharges,
                                       AmountType AmountDue,
                                       VendNumType VendNum,
                                       VendInvNumType InvNum,
                                       DateType InvDate,
                                       DateType DistDate,
                                       FSReconBatchIdType BatchId,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSExpenseReconSp";

                appDB.AddCommandParameter(cmd, "Mode", Mode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PayType", PayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MiscCharges", MiscCharges, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AmountDue", AmountDue, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNum", VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvDate", InvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DistDate", DistDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BatchId", BatchId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
