//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSRecurrVoucherPreviewToGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
    public interface ICHSRecurrVoucherPreviewToGen
    {
        int CHSRecurrVoucherPreviewToGenSp(GenericIntType ID,
                                           DateType TransDate,
                                           TransNatType TypeCode,
                                           UsernameType UserName,
                                           ref GenericMedCodeType VoucherNumber,
                                           ref InfobarType Infobar);
    }

    public class CHSRecurrVoucherPreviewToGen : ICHSRecurrVoucherPreviewToGen
    {
        readonly IApplicationDB appDB;

        public CHSRecurrVoucherPreviewToGen(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CHSRecurrVoucherPreviewToGenSp(GenericIntType ID,
                                                  DateType TransDate,
                                                  TransNatType TypeCode,
                                                  UsernameType UserName,
                                                  ref GenericMedCodeType VoucherNumber,
                                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CHSRecurrVoucherPreviewToGenSp";

                appDB.AddCommandParameter(cmd, "ID", ID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TypeCode", TypeCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VoucherNumber", VoucherNumber, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
