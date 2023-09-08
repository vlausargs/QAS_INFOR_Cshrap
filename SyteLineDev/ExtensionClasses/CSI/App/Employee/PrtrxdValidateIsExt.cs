//PROJECT NAME: CSIEmployee
//CLASS NAME: PrtrxdValidateIsExt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrtrxdValidateIsExt
    {
        int PrtrxdValidateIsExtSp(EmpNumType EmpNum,
                                  PrtrxSeqType Seq,
                                  ref InfobarType Infobar);
    }

    public class PrtrxdValidateIsExt : IPrtrxdValidateIsExt
    {
        readonly IApplicationDB appDB;

        public PrtrxdValidateIsExt(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrtrxdValidateIsExtSp(EmpNumType EmpNum,
                                         PrtrxSeqType Seq,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrtrxdValidateIsExtSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
