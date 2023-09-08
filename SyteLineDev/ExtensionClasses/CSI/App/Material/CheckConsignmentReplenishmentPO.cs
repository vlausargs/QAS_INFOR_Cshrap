//PROJECT NAME: CSIMaterial
//CLASS NAME: CheckConsignmentReplenishmentPO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICheckConsignmentReplenishmentPO
    {
        int CheckConsignmentReplenishmentPOSp(ConsignmentTypeType ConsignmentType,
                                              PoNumType ReplenPoNum,
                                              VendNumType VendNum,
                                              ref InfobarType Infobar);
    }

    public class CheckConsignmentReplenishmentPO : ICheckConsignmentReplenishmentPO
    {
        readonly IApplicationDB appDB;

        public CheckConsignmentReplenishmentPO(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckConsignmentReplenishmentPOSp(ConsignmentTypeType ConsignmentType,
                                                     PoNumType ReplenPoNum,
                                                     VendNumType VendNum,
                                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckConsignmentReplenishmentPOSp";

                appDB.AddCommandParameter(cmd, "ConsignmentType", ConsignmentType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ReplenPoNum", ReplenPoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "VendNum", VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
