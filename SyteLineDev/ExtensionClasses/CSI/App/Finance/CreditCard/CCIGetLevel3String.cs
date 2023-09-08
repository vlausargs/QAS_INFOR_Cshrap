//PROJECT NAME: Finance
//CLASS NAME: CCIGetLevel3String.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
    public class CCIGetLevel3String : ICCIGetLevel3String
    {
        readonly IApplicationDB appDB;


        public CCIGetLevel3String(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Level3,
        string Infobar) CCIGetLevel3StringSp(string CardSystem,
        string InvNum,
        decimal? TotalAmt,
        string CustRef,
        string Level3,
        string Infobar)
        {
            StringType _CardSystem = CardSystem;
            StringType _InvNum = InvNum;
            DecimalType _TotalAmt = TotalAmt;
            StringType _CustRef = CustRef;
            StringType _Level3 = Level3;
            StringType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CCIGetLevel3StringSp";

                appDB.AddCommandParameter(cmd, "CardSystem", _CardSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TotalAmt", _TotalAmt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustRef", _CustRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Level3", _Level3, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Level3 = _Level3;
                Infobar = _Infobar;

                return (Severity, Level3, Infobar);
            }
        }
    }
}
