//PROJECT NAME: CSIMaterial
//CLASS NAME: ProdMixCompareRouting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IProdMixCompareRouting
    {
        int ProdMixCompareRoutingSp(ItemType OldLeadItem,
                                    ItemType NewLeadItem,
                                    ref InfobarType Infobar);
    }

    public class ProdMixCompareRouting : IProdMixCompareRouting
    {
        readonly IApplicationDB appDB;

        public ProdMixCompareRouting(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ProdMixCompareRoutingSp(ItemType OldLeadItem,
                                           ItemType NewLeadItem,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProdMixCompareRoutingSp";

                appDB.AddCommandParameter(cmd, "OldLeadItem", OldLeadItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewLeadItem", NewLeadItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
