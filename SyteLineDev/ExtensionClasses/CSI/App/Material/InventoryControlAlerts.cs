//PROJECT NAME: CSIMaterial
//CLASS NAME: InventoryControlAlerts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IInventoryControlAlerts
    {
        int InventoryControlAlertsSp(ref NumberOfLinesType ItemsBelowSafetyStock,
                                     ref NumberOfLinesType ItemsQuarantined,
                                     ref NumberOfLinesType NumberOfUserTasks,
                                     ref NumberOfLinesType NumberOfEventMessages);
    }

    public class InventoryControlAlerts : IInventoryControlAlerts
    {
        readonly IApplicationDB appDB;

        public InventoryControlAlerts(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int InventoryControlAlertsSp(ref NumberOfLinesType ItemsBelowSafetyStock,
                                            ref NumberOfLinesType ItemsQuarantined,
                                            ref NumberOfLinesType NumberOfUserTasks,
                                            ref NumberOfLinesType NumberOfEventMessages)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InventoryControlAlertsSp";

                appDB.AddCommandParameter(cmd, "ItemsBelowSafetyStock", ItemsBelowSafetyStock, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemsQuarantined", ItemsQuarantined, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NumberOfUserTasks", NumberOfUserTasks, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "NumberOfEventMessages", NumberOfEventMessages, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
