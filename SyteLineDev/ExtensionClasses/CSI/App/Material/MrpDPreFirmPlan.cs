//PROJECT NAME: CSIMaterial
//CLASS NAME: MrpDPreFirmPlan.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IMrpDPreFirmPlan
    {
        int MrpDPreFirmPlanSp(ItemType PItem,
                              ref JobTypeType PRefType,
                              ref InfobarType Infobar);
    }

    public class MrpDPreFirmPlan : IMrpDPreFirmPlan
    {
        readonly IApplicationDB appDB;

        public MrpDPreFirmPlan(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int MrpDPreFirmPlanSp(ItemType PItem,
                                     ref JobTypeType PRefType,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MrpDPreFirmPlanSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefType", PRefType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
