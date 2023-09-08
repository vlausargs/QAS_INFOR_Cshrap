//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckCostItemAtWhseForConsignment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICheckCostItemAtWhseForConsignment
    {
        int CheckCostItemAtWhseForConsignmentSp(ref ConsignmentTypeType ConsignmentType,
                                                ref InfobarType Infobar);
    }

    public class CheckCostItemAtWhseForConsignment : ICheckCostItemAtWhseForConsignment
    {
        readonly IApplicationDB appDB;

        public CheckCostItemAtWhseForConsignment(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckCostItemAtWhseForConsignmentSp(ref ConsignmentTypeType ConsignmentType,
                                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckCostItemAtWhseForConsignmentSp";

                appDB.AddCommandParameter(cmd, "ConsignmentType", ConsignmentType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
