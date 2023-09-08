//PROJECT NAME: ReportExt
//CLASS NAME: SLQCCustAvailToShipReport.cs

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
	[IDOExtensionClass("SLQCCustAvailToShipReport")]
	public class SLQCCustAvailToShipReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_CustAvailToShipSSRSSp([Optional] DateTime? CutoffDate,
		[Optional] string BegCust,
		[Optional] string EndCust,
		[Optional] string BegOrder,
		[Optional] string EndOrder,
		[Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string BegWhse,
		[Optional] string EndWhse,
		[Optional] string CoType,
		[Optional] string COLineStat,
		[Optional] string COStat,
		[Optional] string sortby,
		[Optional] int? ShipEarly,
		[Optional] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_CustAvailToShipSSRSExt = new Rpt_RSQC_CustAvailToShipSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_CustAvailToShipSSRSExt.Rpt_RSQC_CustAvailToShipSSRSSp(CutoffDate,
				BegCust,
				EndCust,
				BegOrder,
				EndOrder,
				BegItem,
				EndItem,
				BegWhse,
				EndWhse,
				CoType,
				COLineStat,
				COStat,
				sortby,
				ShipEarly,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
