//PROJECT NAME: CSIAdmin
//CLASS NAME: MobileSPMenuItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IMobileSPMenuItems
    {
        int MobileSPMenuItemsSp(ref IntType MaxMenuItems);
    }

    public class MobileSPMenuItems : IMobileSPMenuItems
    {
        IApplicationDB appDB;

        public MobileSPMenuItems(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MobileSPMenuItemsSp(ref IntType MaxMenuItems)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MobileSPMenuItemsSp";

                appDB.AddCommandParameter(cmd, "MaxMenuItems", MaxMenuItems, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
