//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogValidateSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrLogValidateSeq
    {
        int PrLogValidateSeqSp(EmpNumType EmpNum,
                               PrLogSeqType EmpSeq,
                               ref InfobarType Infobar);
    }

    public class PrLogValidateSeq : IPrLogValidateSeq
    {
        readonly IApplicationDB appDB;

        public PrLogValidateSeq(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrLogValidateSeqSp(EmpNumType EmpNum,
                                      PrLogSeqType EmpSeq,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrLogValidateSeqSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpSeq", EmpSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
