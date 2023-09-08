//PROJECT NAME: CSIAdmin
//CLASS NAME: MobileControllerMenuItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
    public interface IMobileControllerMenuItems
    {
        int MobileControllerMenuItemsSp(ref IntType MaxMenuItems);
    }

    public class MobileControllerMenuItems : IMobileControllerMenuItems
    {
        IApplicationDB appDB;

        public MobileControllerMenuItems(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MobileControllerMenuItemsSp(ref IntType MaxMenuItems)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MobileControllerMenuItemsSp";

                appDB.AddCommandParameter(cmd, "MaxMenuItems", MaxMenuItems, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}