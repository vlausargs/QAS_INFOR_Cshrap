//PROJECT NAME: CSIVendor
//CLASS NAME: POReceivingCleanup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
    public interface IPOReceivingCleanup
    {
        int POReceivingCleanupSp();
    }

    public class POReceivingCleanup : IPOReceivingCleanup
    {
        readonly IApplicationDB appDB;

        public POReceivingCleanup(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int POReceivingCleanupSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "POReceivingCleanupSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
