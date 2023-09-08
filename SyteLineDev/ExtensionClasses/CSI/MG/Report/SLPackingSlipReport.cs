//PROJECT NAME: ReportExt
//CLASS NAME: SLPackingSlipReport.cs

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
    [IDOExtensionClass("SLPackingSlipReport")]
    public class SLPackingSlipReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PackingSlipSp([Optional] string PckCall,
		[Optional] int? MinPackNum,
		[Optional] int? MaxPackNum,
		[Optional] int? PrintOrderText,
		[Optional] int? PrintLineText,
		[Optional] int? PrintDescription,
		[Optional] int? PrintPlanningItemMaterials,
		[Optional] int? IncludeSerialNumbers,
		[Optional] int? ShowInternal,
		[Optional] int? ShowExternal,
		[Optional] int? PrintItemOverview,
		[Optional] int? DisplayHeader,
		[Optional] int? CoTypeRegular,
		[Optional] int? CoTypeBlanket,
		[Optional] string CoStat,
		[Optional] string CoItemStat,
		[Optional] string OrderStarting,
		[Optional] string OrderEnding,
		[Optional] int? OrderLineStarting,
		[Optional] int? OrderReleaseStarting,
		[Optional] int? OrderLineEnding,
		[Optional] int? OrderReleaseEnding,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] DateTime? OrderDateStarting,
		[Optional] DateTime? OrderDateEnding,
		[Optional] DateTime? DueDateStarting,
		[Optional] DateTime? DueDateEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PackingSlipExt = new Rpt_PackingSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PackingSlipExt.Rpt_PackingSlipSp(PckCall,
				MinPackNum,
				MaxPackNum,
				PrintOrderText,
				PrintLineText,
				PrintDescription,
				PrintPlanningItemMaterials,
				IncludeSerialNumbers,
				ShowInternal,
				ShowExternal,
				PrintItemOverview,
				DisplayHeader,
				CoTypeRegular,
				CoTypeBlanket,
				CoStat,
				CoItemStat,
				OrderStarting,
				OrderEnding,
				OrderLineStarting,
				OrderReleaseStarting,
				OrderLineEnding,
				OrderReleaseEnding,
				CustomerStarting,
				CustomerEnding,
				OrderDateStarting,
				OrderDateEnding,
				DueDateStarting,
				DueDateEnding,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
