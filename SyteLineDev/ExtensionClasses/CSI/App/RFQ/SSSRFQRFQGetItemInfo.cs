//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQRFQGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQRFQGetItemInfo
    {
        int SSSRFQRFQGetItemInfoSp(string Item,
                                   ref string Description,
                                   ref string UM,
                                   ref string BadItemMsg,
                                   ref string Infobar);
    }

    public class SSSRFQRFQGetItemInfo : ISSSRFQRFQGetItemInfo
    {
        readonly IApplicationDB appDB;

        public SSSRFQRFQGetItemInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRFQRFQGetItemInfoSp(string Item,
                                          ref string Description,
                                          ref string UM,
                                          ref string BadItemMsg,
                                          ref string Infobar)
        {
            ItemType _Item = Item;
            DescriptionType _Description = Description;
            UMType _UM = UM;
            Infobar _BadItemMsg = BadItemMsg;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQRFQGetItemInfoSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BadItemMsg", _BadItemMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Description = _Description;
                UM = _UM;
                BadItemMsg = _BadItemMsg;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
