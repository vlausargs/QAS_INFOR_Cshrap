//PROJECT NAME: CSIMaterial
//CLASS NAME: CycleGeneration.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICycleGeneration
    {
        int CycleGenerationSp(WhseType Whse,
                              StringType CycleType,
                              StringType MatlType,
                              StringType ABCCode,
                              ListYesNoType OverwriteRecords,
                              StringType SortBy,
                              ListYesNoType PageBetween,
                              ListYesNoType PrintCutoffQty,
                              ItemType FromItem,
                              ItemType ToItem,
                              LocType FromLoc,
                              LocType ToLoc,
                              ProductCodeType FromProductCode,
                              ProductCodeType ToProductCode,
                              UserCodeType FromPlanCode,
                              UserCodeType ToPlanCode,
                              ref InfobarType Infobar);
    }

    public class CycleGeneration : ICycleGeneration
    {
        readonly IApplicationDB appDB;

        public CycleGeneration(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CycleGenerationSp(WhseType Whse,
                                     StringType CycleType,
                                     StringType MatlType,
                                     StringType ABCCode,
                                     ListYesNoType OverwriteRecords,
                                     StringType SortBy,
                                     ListYesNoType PageBetween,
                                     ListYesNoType PrintCutoffQty,
                                     ItemType FromItem,
                                     ItemType ToItem,
                                     LocType FromLoc,
                                     LocType ToLoc,
                                     ProductCodeType FromProductCode,
                                     ProductCodeType ToProductCode,
                                     UserCodeType FromPlanCode,
                                     UserCodeType ToPlanCode,
                                     ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CycleGenerationSp";

                appDB.AddCommandParameter(cmd, "Whse", Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CycleType", CycleType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MatlType", MatlType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ABCCode", ABCCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OverwriteRecords", OverwriteRecords, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SortBy", SortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PageBetween", PageBetween, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PrintCutoffQty", PrintCutoffQty, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromItem", FromItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToItem", ToItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromLoc", FromLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToLoc", ToLoc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromProductCode", FromProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToProductCode", ToProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromPlanCode", FromPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToPlanCode", ToPlanCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
