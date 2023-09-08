//PROJECT NAME: CSIMaterial
//CLASS NAME: ValidateItemForReplenPOBln.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IValidateItemForReplenPOBln
    {
        int ValidateItemForReplenPOBlnSp(PoNumType PPONum,
                                         ItemType PItem,
                                         ref InfobarType Infobar);
    }

    public class ValidateItemForReplenPOBln : IValidateItemForReplenPOBln
    {
        readonly IApplicationDB appDB;

        public ValidateItemForReplenPOBln(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ValidateItemForReplenPOBlnSp(PoNumType PPONum,
                                                ItemType PItem,
                                                ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ValidateItemForReplenPOBlnSp";

                appDB.AddCommandParameter(cmd, "PPONum", PPONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
