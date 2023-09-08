//PROJECT NAME: CSIEmployee
//CLASS NAME: PrLogGetNextTransNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Employee
{
    public interface IPrLogGetNextTransNum
    {
        int PrLogGetNextTransNumSp(EmpNumType EmpNum,
                                   PrLogSeqType EmpSeq,
                                   ref MatlTransNumType TransNum,
                                   ref InfobarType Infobar);
    }

    public class PrLogGetNextTransNum : IPrLogGetNextTransNum
    {
        readonly IApplicationDB appDB;

        public PrLogGetNextTransNum(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PrLogGetNextTransNumSp(EmpNumType EmpNum,
                                          PrLogSeqType EmpSeq,
                                          ref MatlTransNumType TransNum,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PrLogGetNextTransNumSp";

                appDB.AddCommandParameter(cmd, "EmpNum", EmpNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EmpSeq", EmpSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransNum", TransNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
