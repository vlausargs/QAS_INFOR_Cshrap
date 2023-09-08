//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSDepositValidSro.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSDepositValidSro
    {
        int SSSFSDepositValidSroSp(FSSRONumType SroNum,
                                   ref CustNumType CustNum,
                                   ref AmountType DepositAmt,
                                   ref InfobarType Infobar);
    }

    public class SSSFSDepositValidSro : ISSSFSDepositValidSro
    {
        readonly IApplicationDB appDB;

        public SSSFSDepositValidSro(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSDepositValidSroSp(FSSRONumType SroNum,
                                          ref CustNumType CustNum,
                                          ref AmountType DepositAmt,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSDepositValidSroSp";

                appDB.AddCommandParameter(cmd, "SroNum", SroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DepositAmt", DepositAmt, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
