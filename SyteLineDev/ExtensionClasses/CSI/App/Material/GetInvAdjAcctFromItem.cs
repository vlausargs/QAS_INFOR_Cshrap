//PROJECT NAME: CSIMaterial
//CLASS NAME: GetInvAdjAcctFromItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetInvAdjAcctFromItem
    {
        int GetInvAdjAcctFromItemSp(ItemType PItemItem,
                                    ref AcctType PInvAdjAcct,
                                    ref DescriptionType PChartDescription,
                                    ref Infobar Infobar);
    }

    public class GetInvAdjAcctFromItem : IGetInvAdjAcctFromItem
    {
        readonly IApplicationDB appDB;

        public GetInvAdjAcctFromItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetInvAdjAcctFromItemSp(ItemType PItemItem,
                                           ref AcctType PInvAdjAcct,
                                           ref DescriptionType PChartDescription,
                                           ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetInvAdjAcctFromItemSp";

                appDB.AddCommandParameter(cmd, "PItemItem", PItemItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PInvAdjAcct", PInvAdjAcct, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PChartDescription", PChartDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
