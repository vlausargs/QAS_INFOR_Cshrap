//PROJECT NAME: CSICustomer
//CLASS NAME: CiWorkbenchDel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICiWorkbenchDel
    {
        int CiWorkbenchDelSp(string CustNum,
                             short? ConInvSeq,
                             int? InvLine,
                             string CoNum,
                             short? CoLine,
                             short? CoRelease,
                             string Regen,
                             string Infobar);
    }

    public class CiWorkbenchDel : ICiWorkbenchDel
    {
        readonly IApplicationDB appDB;

        public CiWorkbenchDel(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CiWorkbenchDelSp(string CustNum,
                                    short? ConInvSeq,
                                    int? InvLine,
                                    string CoNum,
                                    short? CoLine,
                                    short? CoRelease,
                                    string Regen,
                                    string Infobar)
        {
            CustNumType _CustNum = CustNum;
            ConInvSeqType _ConInvSeq = ConInvSeq;
            InvLineType _InvLine = InvLine;
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CoReleaseType _CoRelease = CoRelease;
            StringType _Regen = Regen;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CiWorkbenchDelSp";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ConInvSeq", _ConInvSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvLine", _InvLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Regen", _Regen, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
