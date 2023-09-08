//PROJECT NAME: CSIMaterial
//CLASS NAME: SetTrnExportValue.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ISetTrnExportValue
    {
        int SetTrnExportValueSp(TrnNumType TrnNum,
                                SiteType FromSite,
                                SiteType ToSite,
                                ItemType Item,
                                CostPrcType UnitCost,
                                ref AmountType ExportValue,
                                ref InfobarType PromptMsg,
                                ref InfobarType PromptButtons,
                                ref InfobarType Infobar);
    }

    public class SetTrnExportValue : ISetTrnExportValue
    {
        readonly IApplicationDB appDB;

        public SetTrnExportValue(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SetTrnExportValueSp(TrnNumType TrnNum,
                                       SiteType FromSite,
                                       SiteType ToSite,
                                       ItemType Item,
                                       CostPrcType UnitCost,
                                       ref AmountType ExportValue,
                                       ref InfobarType PromptMsg,
                                       ref InfobarType PromptButtons,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SetTrnExportValueSp";

                appDB.AddCommandParameter(cmd, "TrnNum", TrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FromSite", FromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ToSite", ToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UnitCost", UnitCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExportValue", ExportValue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
