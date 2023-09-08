//PROJECT NAME: ReportExt
//CLASS NAME: SLOutboundPurchaseOrderReport.cs

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
    [IDOExtensionClass("SLOutboundPurchaseOrderReport")]
    public class SLOutboundPurchaseOrderReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_OutboundPurchaseOrderSP([Optional] string Begvendnum,
		[Optional] string Endvendnum,
		[Optional] string Begponum,
		[Optional] string Endponum,
		[Optional] DateTime? Begorderdate,
		[Optional] DateTime? Endorderdate,
		[Optional] int? BegorderdateOffset,
		[Optional] int? EndorderdateOffset,
		[Optional] string Begplancode,
		[Optional] string Endplancode,
		[Optional] string BegItem,
		[Optional] string Enditem,
		[Optional] string ExOptprPostedEmp,
		[Optional] int? ExOptszShowDetail,
		[Optional, DefaultParameterValue(1)] int? ShowInternal,
		[Optional, DefaultParameterValue(1)] int? ShowExternal,
		[Optional, DefaultParameterValue(1)] int? PrintEdiPo,
		[Optional, DefaultParameterValue(1)] int? PrintEdiPoItem,
		[Optional, DefaultParameterValue(1)] int? PrintEdiPoBln,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_OutboundPurchaseOrderExt = new Rpt_OutboundPurchaseOrderFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_OutboundPurchaseOrderExt.Rpt_OutboundPurchaseOrderSP(Begvendnum,
				Endvendnum,
				Begponum,
				Endponum,
				Begorderdate,
				Endorderdate,
				BegorderdateOffset,
				EndorderdateOffset,
				Begplancode,
				Endplancode,
				BegItem,
				Enditem,
				ExOptprPostedEmp,
				ExOptszShowDetail,
				ShowInternal,
				ShowExternal,
				PrintEdiPo,
				PrintEdiPoItem,
				PrintEdiPoBln,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
