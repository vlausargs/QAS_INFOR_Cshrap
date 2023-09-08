//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCostMethodCostTypeValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemCostMethodCostTypeValid
    {
        int ItemCostMethodCostTypeValidSp(CostMethodType CostMethod,
                                          CostTypeType CostType,
                                          ref Infobar Infobar);
    }

    public class ItemCostMethodCostTypeValid : IItemCostMethodCostTypeValid
    {
        readonly IApplicationDB appDB;

        public ItemCostMethodCostTypeValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemCostMethodCostTypeValidSp(CostMethodType CostMethod,
                                                 CostTypeType CostType,
                                                 ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemCostMethodCostTypeValidSp";

                appDB.AddCommandParameter(cmd, "CostMethod", CostMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CostType", CostType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
