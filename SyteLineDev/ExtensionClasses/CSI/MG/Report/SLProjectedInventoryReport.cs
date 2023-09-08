//PROJECT NAME: MG
//CLASS NAME: SLProjectedInventoryReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
	[IDOExtensionClass("SLProjectedInventoryReport")]
	public class SLProjectedInventoryReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InventoryBalanceByPeriodSp([Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string ProductCodeStarting,
		[Optional] string ProductCodeENDing,
		[Optional] string PlanCodeStarting,
		[Optional] string PlanCodeENDing,
		[Optional] string MaterialType,
		[Optional] string Source,
		[Optional] string pStocked,
		[Optional] string ABCCode,
		[Optional] int? ExcludeZeroNetRequirements,
		[Optional] int? IncludeTransfers,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_InventoryBalanceByPeriodExt = new Rpt_InventoryBalanceByPeriodFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_InventoryBalanceByPeriodExt.Rpt_InventoryBalanceByPeriodSp(ItemStarting,
				ItemEnding,
				ProductCodeStarting,
				ProductCodeENDing,
				PlanCodeStarting,
				PlanCodeENDing,
				MaterialType,
				Source,
				pStocked,
				ABCCode,
				ExcludeZeroNetRequirements,
				IncludeTransfers,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
