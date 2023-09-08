//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSConPostInv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSConPostInv
    {
        int SSSPOSConPostInvSp(string pContract,
                               DateTime? pBilledThruDateTime,
                               DateTime? pBilledThruDate,
                               Guid? PSessionID,
                               string pContractStatus,
                               string pUserName,
                               decimal? pUserID,
                               string pPartnerID,
                               string pDrawer,
                               ref string Infobar);
    }

    public class SSSPOSConPostInv : ISSSPOSConPostInv
    {
        readonly IApplicationDB appDB;

        public SSSPOSConPostInv(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSConPostInvSp(string pContract,
                                      DateTime? pBilledThruDateTime,
                                      DateTime? pBilledThruDate,
                                      Guid? PSessionID,
                                      string pContractStatus,
                                      string pUserName,
                                      decimal? pUserID,
                                      string pPartnerID,
                                      string pDrawer,
                                      ref string Infobar)
        {
            FSContractType _pContract = pContract;
            DateType _pBilledThruDateTime = pBilledThruDateTime;
            DateType _pBilledThruDate = pBilledThruDate;
            RowPointerType _PSessionID = PSessionID;
            FSContStatType _pContractStatus = pContractStatus;
            UsernameType _pUserName = pUserName;
            TokenType _pUserID = pUserID;
            FSPartnerType _pPartnerID = pPartnerID;
            POSMDrawerType _pDrawer = pDrawer;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSConPostInvSp";

                appDB.AddCommandParameter(cmd, "pContract", _pContract, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBilledThruDateTime", _pBilledThruDateTime, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pBilledThruDate", _pBilledThruDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pContractStatus", _pContractStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pUserName", _pUserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pUserID", _pUserID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pPartnerID", _pPartnerID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pDrawer", _pDrawer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
