//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsNonInvItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpIsNonInvItem
    {
        int ApsCtpIsNonInvItemSp(ItemType PItem,
                                 ref IntType PIsNonInvItem);
    }

    public class ApsCtpIsNonInvItem : IApsCtpIsNonInvItem
    {
        readonly IApplicationDB appDB;

        public ApsCtpIsNonInvItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpIsNonInvItemSp(ItemType PItem,
                                        ref IntType PIsNonInvItem)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpIsNonInvItemSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIsNonInvItem", PIsNonInvItem, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
