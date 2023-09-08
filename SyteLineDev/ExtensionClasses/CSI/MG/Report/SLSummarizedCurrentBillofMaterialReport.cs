//PROJECT NAME: ReportExt
//CLASS NAME: SLSummarizedCurrentBillofMaterialReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLSummarizedCurrentBillofMaterialReport")]
	public class SLSummarizedCurrentBillofMaterialReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SummarizedCurrentBillOfMaterialSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string MaterialType,
		[Optional] string Source,
		[Optional] string Shocked,
		[Optional] string ABCCode,
		[Optional] DateTime? EffectiveDate,
		[Optional] int? PageBetweenItems,
		[Optional] int? PrintOnlyZeroLevelItems,
		[Optional] int? EffectiveDateOffset,
		[Optional] int? DisplayHeader,
		[Optional, DefaultParameterValue(0)] int? PrintCost,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SummarizedCurrentBillOfMaterialExt = new Rpt_SummarizedCurrentBillOfMaterialFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SummarizedCurrentBillOfMaterialExt.Rpt_SummarizedCurrentBillOfMaterialSp(ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeEnding,
				MaterialType,
				Source,
				Shocked,
				ABCCode,
				EffectiveDate,
				PageBetweenItems,
				PrintOnlyZeroLevelItems,
				EffectiveDateOffset,
				DisplayHeader,
				PrintCost,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
