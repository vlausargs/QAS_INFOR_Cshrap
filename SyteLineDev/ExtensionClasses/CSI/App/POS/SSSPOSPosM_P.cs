//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSPosM_P.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSPosM_P
    {
        int SSSPOSPosM_PSp(string POSNum,
                           decimal? UserID,
                           string ParmCurrCode,
                           string ParmSite,
                           string CurUserCode,
                           Guid? SessionID,
                           ref string TInvNum,
                           ref string Infobar);
    }

    public class SSSPOSPosM_P : ISSSPOSPosM_P
    {
        readonly IApplicationDB appDB;

        public SSSPOSPosM_P(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSPosM_PSp(string POSNum,
                                  decimal? UserID,
                                  string ParmCurrCode,
                                  string ParmSite,
                                  string CurUserCode,
                                  Guid? SessionID,
                                  ref string TInvNum,
                                  ref string Infobar)
        {
            POSMNumType _POSNum = POSNum;
            TokenType _UserID = UserID;
            CurrCodeType _ParmCurrCode = ParmCurrCode;
            SiteType _ParmSite = ParmSite;
            TakenByType _CurUserCode = CurUserCode;
            RowPointerType _SessionID = SessionID;
            InvNumType _TInvNum = TInvNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSPosM_PSp";

                appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParmCurrCode", _ParmCurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TInvNum", _TInvNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TInvNum = _TInvNum;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
