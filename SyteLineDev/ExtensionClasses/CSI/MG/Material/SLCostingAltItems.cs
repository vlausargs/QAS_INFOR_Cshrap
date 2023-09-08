//PROJECT NAME: MaterialExt
//CLASS NAME: SLCostingAltItems.cs

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
	[IDOExtensionClass("SLCostingAltItems")]
	public class SLCostingAltItems : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable CLM_CostingAltGetCompareSp(string CostingAlt,
            [Optional] string CostType,
            [Optional] string Whse,
            [Optional] string CostingAlt2Compare,
            [Optional] string ItemCompare,
            [Optional] string FilterString,
            [Optional] string Infobar)
        {
            var iCLM_CostingAltGetCompareExt = new CLM_CostingAltGetCompareFactory().Create(this, true);

            var result = iCLM_CostingAltGetCompareExt.CLM_CostingAltGetCompareSp(CostingAlt,
                CostType,
                Whse,
                CostingAlt2Compare,
                ItemCompare,
                FilterString,
                Infobar);


            if (result.Data is null)
                return new DataTable();
            else
            {
                IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
                return recordCollectionToDataTable.ToDataTable(result.Data.Items);
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
