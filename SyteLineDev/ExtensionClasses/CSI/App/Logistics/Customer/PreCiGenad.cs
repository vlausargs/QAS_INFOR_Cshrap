//PROJECT NAME: CSICustomer
//CLASS NAME: PreCiGenad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IPreCiGenad
    {
        int PreCiGenadSp(string DoInvoice,
                         string DoNum,
                         int? DoLine,
                         short? DoSeq,
                         string CustPo,
                         string CoNum,
                         short? CoLine,
                         short? CoRelease,
                         ref byte? NewHdr,
                         ref string Infobar);
    }

    public class PreCiGenad : IPreCiGenad
    {
        readonly IApplicationDB appDB;

        public PreCiGenad(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PreCiGenadSp(string DoInvoice,
                                string DoNum,
                                int? DoLine,
                                short? DoSeq,
                                string CustPo,
                                string CoNum,
                                short? CoLine,
                                short? CoRelease,
                                ref byte? NewHdr,
                                ref string Infobar)
        {
            DoInvoiceType _DoInvoice = DoInvoice;
            DoNumType _DoNum = DoNum;
            DoLineType _DoLine = DoLine;
            DoSeqType _DoSeq = DoSeq;
            CustPoType _CustPo = CustPo;
            CoNumType _CoNum = CoNum;
            CoLineType _CoLine = CoLine;
            CoReleaseType _CoRelease = CoRelease;
            FlagNyType _NewHdr = NewHdr;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PreCiGenadSp";

                appDB.AddCommandParameter(cmd, "DoInvoice", _DoInvoice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DoNum", _DoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DoLine", _DoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DoSeq", _DoSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustPo", _CustPo, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewHdr", _NewHdr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                NewHdr = _NewHdr;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
