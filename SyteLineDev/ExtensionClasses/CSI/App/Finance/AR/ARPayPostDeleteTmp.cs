//PROJECT NAME: CSICustomer
//CLASS NAME: ARPayPostDeleteTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.AR
{
    public interface IARPayPostDeleteTmp
    {
        int ARPayPostDeleteTmpSp(RowPointer PSessionID);
    }

    public class ARPayPostDeleteTmp : IARPayPostDeleteTmp
    {
        readonly IApplicationDB appDB;

        public ARPayPostDeleteTmp(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ARPayPostDeleteTmpSp(RowPointer PSessionID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ARPayPostDeleteTmpSp";

                appDB.AddCommandParameter(cmd, "PSessionID", PSessionID, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
