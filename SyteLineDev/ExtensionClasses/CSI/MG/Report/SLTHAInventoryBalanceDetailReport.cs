//PROJECT NAME: ReportExt
//CLASS NAME: SLTHAInventoryBalanceDetailReport.cs

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
	[IDOExtensionClass("SLTHAInventoryBalanceDetailReport")]
	public class SLTHAInventoryBalanceDetailReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable THARpt_InventoryBalanceSp([Optional] string ProductCodeStarting,
		[Optional] string ProductCodeEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] string LocStarting,
		[Optional] string LocEnding,
		[Optional] DateTime? TransDateStarting,
		[Optional] DateTime? TransDateEnding,
		[Optional] string ReasonCodeStarting,
		[Optional] string ReasonCodeEnding,
		[Optional, DefaultParameterValue(0)] int? SummaryDtl,
		[Optional] int? OneItmPerPg,
		[Optional] int? IncludeMoveTrn,
		[Optional] int? IncludeNonNetStk,
		[Optional] int? DisplayHeader,
		[Optional] int? TransDateStartingOffset,
		[Optional] int? TransDateEndingOffset,
		[Optional] string pSite,
		[Optional] string MessageLanguage,
		[Optional] string DocumentNumStarting,
		[Optional] string DocumentNumEnding)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iTHARpt_InventoryBalanceExt = new THARpt_InventoryBalanceFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iTHARpt_InventoryBalanceExt.THARpt_InventoryBalanceSp(ProductCodeStarting,
				ProductCodeEnding,
				ItemStarting,
				ItemEnding,
				WhseStarting,
				WhseEnding,
				LocStarting,
				LocEnding,
				TransDateStarting,
				TransDateEnding,
				ReasonCodeStarting,
				ReasonCodeEnding,
				SummaryDtl,
				OneItmPerPg,
				IncludeMoveTrn,
				IncludeNonNetStk,
				DisplayHeader,
				TransDateStartingOffset,
				TransDateEndingOffset,
				pSite,
				MessageLanguage,
				DocumentNumStarting,
				DocumentNumEnding);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
