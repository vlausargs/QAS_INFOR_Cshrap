//PROJECT NAME: CSIFinance
//CLASS NAME: CopyTemplateToGLVoucher.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance
{
    public interface ICopyTemplateToGLVoucher
    {
        (int? ReturnCode, string Infobar) CopyTemplateToGLVoucherSp(string FromTemplate,
        string ToGLVoucher,
        string Infobar,
        DateTime? TranDate = null);
    }

    public class CopyTemplateToGLVoucher : ICopyTemplateToGLVoucher
    {
        readonly IApplicationDB appDB;

        public CopyTemplateToGLVoucher(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) CopyTemplateToGLVoucherSp(string FromTemplate,
        string ToGLVoucher,
        string Infobar,
        DateTime? TranDate = null)
        {
            InvNumVoucherType _FromTemplate = FromTemplate;
            InvNumVoucherType _ToGLVoucher = ToGLVoucher;
            Infobar _Infobar = Infobar;
            DateType _TranDate = TranDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CopyTemplateToGLVoucherSp";

                appDB.AddCommandParameter(cmd, "FromTemplate", _FromTemplate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToGLVoucher", _ToGLVoucher, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TranDate", _TranDate, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
