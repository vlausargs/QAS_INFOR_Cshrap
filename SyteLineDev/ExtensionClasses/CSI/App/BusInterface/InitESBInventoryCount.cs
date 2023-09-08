//PROJECT NAME: BusInterface
//CLASS NAME: InitESBInventoryCount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.BusInterface
{
    public interface IInitESBInventoryCount
    {
        (int? ReturnCode, string InfoBar) InitESBInventoryCountSp(string InfoBar);
    }

    public class InitESBInventoryCount : IInitESBInventoryCount
    {
        readonly IApplicationDB appDB;

        public InitESBInventoryCount(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string InfoBar) InitESBInventoryCountSp(string InfoBar)
        {
            InfobarType _InfoBar = InfoBar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InitESBInventoryCountSp";

                appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                InfoBar = _InfoBar;

                return (Severity, InfoBar);
            }
        }
    }
}
