//PROJECT NAME: CSIMaterial
//CLASS NAME: CostingAnalysisAlternativeRollCostsToCurrent.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ICostingAnalysisAlternativeRollCostsToCurrent
    {
        int CostingAnalysisAlternativeRollCostsToCurrentSp(CostingAlternativeType CostingAlt,
                                                           ProductCodeType ProductCodeStarting,
                                                           ProductCodeType ProductCodeEnding,
                                                           ItemType ItemStarting,
                                                           ItemType ItemEnding,
                                                           ListYesNoType UpdMaterialCosts,
                                                           ListYesNoType UpdMarkupVar,
                                                           ListYesNoType UpdFixedMatlOvhd,
                                                           ListYesNoType UpdVariableMatlOvhd,
                                                           ListYesNoType UpdPurchOvhdVar,
                                                           ListYesNoType UpdFixedOverhead,
                                                           ListYesNoType UpdVariableOverhead,
                                                           ListYesNoType UpdSetupRate,
                                                           ListYesNoType UpdRunRate,
                                                           ListYesNoType UpdFixMachOvhd,
                                                           ListYesNoType UpdVarMchOvhd,
                                                           ListYesNoType UpdOverheadBasisVar,
                                                           ListYesNoType UpdEfficiency,
                                                           ref InfobarType Infobar);
    }

    public class CostingAnalysisAlternativeRollCostsToCurrent : ICostingAnalysisAlternativeRollCostsToCurrent
    {
        readonly IApplicationDB appDB;

        public CostingAnalysisAlternativeRollCostsToCurrent(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CostingAnalysisAlternativeRollCostsToCurrentSp(CostingAlternativeType CostingAlt,
                                                                  ProductCodeType ProductCodeStarting,
                                                                  ProductCodeType ProductCodeEnding,
                                                                  ItemType ItemStarting,
                                                                  ItemType ItemEnding,
                                                                  ListYesNoType UpdMaterialCosts,
                                                                  ListYesNoType UpdMarkupVar,
                                                                  ListYesNoType UpdFixedMatlOvhd,
                                                                  ListYesNoType UpdVariableMatlOvhd,
                                                                  ListYesNoType UpdPurchOvhdVar,
                                                                  ListYesNoType UpdFixedOverhead,
                                                                  ListYesNoType UpdVariableOverhead,
                                                                  ListYesNoType UpdSetupRate,
                                                                  ListYesNoType UpdRunRate,
                                                                  ListYesNoType UpdFixMachOvhd,
                                                                  ListYesNoType UpdVarMchOvhd,
                                                                  ListYesNoType UpdOverheadBasisVar,
                                                                  ListYesNoType UpdEfficiency,
                                                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CostingAnalysisAlternativeRollCostsToCurrentSp";

                appDB.AddCommandParameter(cmd, "CostingAlt", CostingAlt, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCodeStarting", ProductCodeStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ProductCodeEnding", ProductCodeEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemStarting", ItemStarting, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ItemEnding", ItemEnding, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdMaterialCosts", UpdMaterialCosts, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdMarkupVar", UpdMarkupVar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdFixedMatlOvhd", UpdFixedMatlOvhd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdVariableMatlOvhd", UpdVariableMatlOvhd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdPurchOvhdVar", UpdPurchOvhdVar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdFixedOverhead", UpdFixedOverhead, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdVariableOverhead", UpdVariableOverhead, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdSetupRate", UpdSetupRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdRunRate", UpdRunRate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdFixMachOvhd", UpdFixMachOvhd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdVarMchOvhd", UpdVarMchOvhd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdOverheadBasisVar", UpdOverheadBasisVar, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UpdEfficiency", UpdEfficiency, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
