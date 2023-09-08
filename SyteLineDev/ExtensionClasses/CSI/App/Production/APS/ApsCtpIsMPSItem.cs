//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpIsMPSItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpIsMPSItem
    {
        int ApsCtpIsMPSItemSp(ItemType PItem,
                              ref IntType PIsMPSItem);
    }

    public class ApsCtpIsMPSItem : IApsCtpIsMPSItem
    {
        readonly IApplicationDB appDB;

        public ApsCtpIsMPSItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpIsMPSItemSp(ItemType PItem,
                                     ref IntType PIsMPSItem)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpIsMPSItemSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PIsMPSItem", PIsMPSItem, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
