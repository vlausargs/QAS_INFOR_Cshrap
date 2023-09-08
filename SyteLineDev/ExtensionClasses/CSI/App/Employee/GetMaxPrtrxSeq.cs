//PROJECT NAME: CSIEmployee
//CLASS NAME: GetMaxPrtrxSeq.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IGetMaxPrtrxSeq
    {
        int GetMaxPrtrxSeqSp(EmpNumType pEmpNum,
                             ref PrtrxSeqType rSequence,
                             ref InfobarType Infobar);
    }

    public class GetMaxPrtrxSeq : IGetMaxPrtrxSeq
    {
        readonly IApplicationDB appDB;

        public GetMaxPrtrxSeq(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetMaxPrtrxSeqSp(EmpNumType pEmpNum,
                                    ref PrtrxSeqType rSequence,
                                    ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetMaxPrtrxSeqSp";

                appDB.AddCommandParameter(cmd, "pEmpNum", pEmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "rSequence", rSequence, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
