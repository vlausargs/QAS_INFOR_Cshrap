//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemCcSet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItemCcSet
    {
        int ItemCcSetSp(Flag RollBackonProcessCount,
                        CycleTypeType CycleType,
                        CycleFreqType CycleFreq,
                        DateType LastCount,
                        StringType AbcCode,
                        ItemType BegItem,
                        ItemType EndItem,
                        ProductCodeType BegProductCode,
                        ProductCodeType EndProductCode,
                        UserCodeType BegPlanCode,
                        UserCodeType EndPlanCode,
                        WhseType BegWhse,
                        WhseType EndWhse,
                        ref IntType ProcessCount,
                        ref InfobarType Infobar);
    }

    public class ItemCcSet : IItemCcSet
    {
        readonly IApplicationDB appDB;

        public ItemCcSet(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ItemCcSetSp(Flag RollBackonProcessCount,
                               CycleTypeType CycleType,
                               CycleFreqType CycleFreq,
                               DateType LastCount,
                               StringType AbcCode,
                               ItemType BegItem,
                               ItemType EndItem,
                               ProductCodeType BegProductCode,
                               ProductCodeType EndProductCode,
                               UserCodeType BegPlanCode,
                               UserCodeType EndPlanCode,
                               WhseType BegWhse,
                               WhseType EndWhse,
                               ref IntType ProcessCount,
                               ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ItemCcSetSp";

                appDB.AddCommandParameter(cmd, "RollBackonProcessCount", RollBackonProcessCount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CycleType", CycleType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CycleFreq", CycleFreq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "LastCount", LastCount, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AbcCode", AbcCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegItem", BegItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegProductCode", BegProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProductCode", EndProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegPlanCode", BegPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndPlanCode", EndPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BegWhse", BegWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndWhse", EndWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProcessCount", ProcessCount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
