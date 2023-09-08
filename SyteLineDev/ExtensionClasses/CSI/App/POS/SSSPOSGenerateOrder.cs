//PROJECT NAME: CSIPOS
//CLASS NAME: SSSPOSGenerateOrder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.POS
{
    public interface ISSSPOSGenerateOrder
    {
        int SSSPOSGenerateOrderSp(string OrderType,
                                  string CashDrawer,
                                  string CoNum,
                                  string PartnerID,
                                  string PartnerName,
                                  string UserName,
                                  ref string POSNum,
                                  ref string Infobar);
    }

    public class SSSPOSGenerateOrder : ISSSPOSGenerateOrder
    {
        readonly IApplicationDB appDB;

        public SSSPOSGenerateOrder(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSPOSGenerateOrderSp(string OrderType,
                                         string CashDrawer,
                                         string CoNum,
                                         string PartnerID,
                                         string PartnerName,
                                         string UserName,
                                         ref string POSNum,
                                         ref string Infobar)
        {
            StringType _OrderType = OrderType;
            POSMDrawerType _CashDrawer = CashDrawer;
            CoNumType _CoNum = CoNum;
            FSPartnerType _PartnerID = PartnerID;
            NameType _PartnerName = PartnerName;
            UsernameType _UserName = UserName;
            POSMNumType _POSNum = POSNum;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSPOSGenerateOrderSp";

                appDB.AddCommandParameter(cmd, "OrderType", _OrderType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CashDrawer", _CashDrawer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PartnerName", _PartnerName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserName", _UserName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POSNum", _POSNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                POSNum = _POSNum;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
