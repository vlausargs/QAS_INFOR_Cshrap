//PROJECT NAME: ReportExt
//CLASS NAME: SLAvailableInventorytoReserveReport.cs

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
	[IDOExtensionClass("SLAvailableInventorytoReserveReport")]
	public class SLAvailableInventorytoReserveReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_AvailableInventorytoReserveSp([Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] string ItemStarting,
		[Optional] string ItemEnding,
		[Optional] string pSite,
		int? IncludeSerialNumber)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_AvailableInventorytoReserveExt = new Rpt_AvailableInventorytoReserveFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_AvailableInventorytoReserveExt.Rpt_AvailableInventorytoReserveSp(WhseStarting,
				WhseEnding,
				ItemStarting,
				ItemEnding,
				pSite,
				IncludeSerialNumber);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
