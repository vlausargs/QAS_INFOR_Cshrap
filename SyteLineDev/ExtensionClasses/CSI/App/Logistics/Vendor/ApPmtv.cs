//PROJECT NAME: CSIVendor
//CLASS NAME: ApPmtv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IApPmtv
    {
        int ApPmtvSp(string PBegVendNum,
                     string PEndVendNum,
                     string PBegName,
                     string PEndName,
                     string PPayType,
                     string PBankCode,
                     ref string Infobar);
    }

    public class ApPmtv : IApPmtv
    {
        readonly IApplicationDB appDB;

        public ApPmtv(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApPmtvSp(string PBegVendNum,
                            string PEndVendNum,
                            string PBegName,
                            string PEndName,
                            string PPayType,
                            string PBankCode,
                            ref string Infobar)
        {
            VendNumType _PBegVendNum = PBegVendNum;
            VendNumType _PEndVendNum = PEndVendNum;
            NameType _PBegName = PBegName;
            NameType _PEndName = PEndName;
            StringType _PPayType = PPayType;
            BankCodeType _PBankCode = PBankCode;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApPmtvSp";

                appDB.AddCommandParameter(cmd, "PBegVendNum", _PBegVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndVendNum", _PEndVendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBegName", _PBegName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndName", _PEndName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PPayType", _PPayType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
