//PROJECT NAME: MaterialExt
//CLASS NAME: SLCostingAlts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLCostingAlts")]
    public class SLCostingAlts : CSIExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyCostingAnalysisAlternativeSp(string CostingAlt,
			string CostingAltDescription,
			string BOMType,
			string Whse,
			string CostingAltFrom,
			int? CopyRouting,
			string PMTCode,
			string ABCCode,
			string CostMethod,
			string MatlType,
			string ProductCodeStarting,
			string ProductCodeEnding,
			string ItemStarting,
			string ItemEnding,
			ref string Infobar)
		{
			var iCopyCostingAnalysisAlternativeExt = new CopyCostingAnalysisAlternativeFactory().Create(this, true);
			
			var result = iCopyCostingAnalysisAlternativeExt.CopyCostingAnalysisAlternativeSp(CostingAlt,
				CostingAltDescription,
				BOMType,
				Whse,
				CostingAltFrom,
				CopyRouting,
				PMTCode,
				ABCCode,
				CostMethod,
				MatlType,
				ProductCodeStarting,
				ProductCodeEnding,
				ItemStarting,
				ItemEnding,
				Infobar);
			
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CostingAnalysisAlternativeRollCostsToCurrentSp(string CostingAlt,
                                                                          string ProductCodeStarting,
                                                                          string ProductCodeEnding,
                                                                          string ItemStarting,
                                                                          string ItemEnding,
                                                                          byte? UpdMaterialCosts,
                                                                          byte? UpdMarkupVar,
                                                                          byte? UpdFixedMatlOvhd,
                                                                          byte? UpdVariableMatlOvhd,
                                                                          byte? UpdPurchOvhdVar,
                                                                          byte? UpdFixedOverhead,
                                                                          byte? UpdVariableOverhead,
                                                                          byte? UpdSetupRate,
                                                                          byte? UpdRunRate,
                                                                          byte? UpdFixMachOvhd,
                                                                          byte? UpdVarMchOvhd,
                                                                          byte? UpdOverheadBasisVar,
                                                                          byte? UpdEfficiency,
                                                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCostingAnalysisAlternativeRollCostsToCurrentExt = new CostingAnalysisAlternativeRollCostsToCurrentFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCostingAnalysisAlternativeRollCostsToCurrentExt.CostingAnalysisAlternativeRollCostsToCurrentSp(CostingAlt,
                                                                                                ProductCodeStarting,
                                                                                                ProductCodeEnding,
                                                                                                ItemStarting,
                                                                                                ItemEnding,
                                                                                                UpdMaterialCosts,
                                                                                                UpdMarkupVar,
                                                                                                UpdFixedMatlOvhd,
                                                                                                UpdVariableMatlOvhd,
                                                                                                UpdPurchOvhdVar,
                                                                                                UpdFixedOverhead,
                                                                                                UpdVariableOverhead,
                                                                                                UpdSetupRate,
                                                                                                UpdRunRate,
                                                                                                UpdFixMachOvhd,
                                                                                                UpdVarMchOvhd,
                                                                                                UpdOverheadBasisVar,
                                                                                                UpdEfficiency,
                                                                                                ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CostingAnalysisAlternativeRollUpSp(string CostingAlt,
                                                    string PMTCode,
                                                    string ABCCode,
                                                    string CostMethod,
                                                    string MatlType,
                                                    string ProductCodeStarting,
                                                    string ProductCodeEnding,
                                                    string ItemStarting,
                                                    string ItemEnding,
                                                    byte? IteminAlternativeList,
                                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCostingAnalysisAlternativeRollExt = new CostingAnalysisAlternativeRollFactory().Create(appDb);

                var result = iCostingAnalysisAlternativeRollExt.CostingAnalysisAlternativeRollUp(CostingAlt,
                                                                                                 PMTCode,
                                                                                                 ABCCode,
                                                                                                 CostMethod,
                                                                                                 MatlType,
                                                                                                 ProductCodeStarting,
                                                                                                 ProductCodeEnding,
                                                                                                 ItemStarting,
                                                                                                 ItemEnding,
                                                                                                 IteminAlternativeList,
                                                                                                 Infobar);

                int Severity = result.ReturnCode.Value;
                Infobar = result.Infobar;
                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CopyCostingAnalysisAlternativeRoutingSp(string CostingAlt,
		string Item,
		[Optional, DefaultParameterValue(null)] string CostingAltFrom,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCopyCostingAnalysisAlternativeRoutingExt = new CopyCostingAnalysisAlternativeRoutingFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCopyCostingAnalysisAlternativeRoutingExt.CopyCostingAnalysisAlternativeRoutingSp(CostingAlt,
				Item,
				CostingAltFrom,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
