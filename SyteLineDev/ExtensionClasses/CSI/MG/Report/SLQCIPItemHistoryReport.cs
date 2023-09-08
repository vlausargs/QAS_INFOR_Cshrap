//PROJECT NAME: ReportExt
//CLASS NAME: SLQCIPItemHistoryReport.cs

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
	[IDOExtensionClass("SLQCIPItemHistoryReport")]
	public class SLQCIPItemHistoryReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_IPItemHistorySSRSSp([Optional] string begjob,
		[Optional] string endjob,
		[Optional] int? begsuffix,
		[Optional] int? endsuffix,
		[Optional] string begpsnum,
		[Optional] string endpsnum,
		[Optional] DateTime? begtdate,
		[Optional] DateTime? endtdate,
		[Optional] int? PageBetweenItems,
		[Optional] int? DisplayHeader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_IPItemHistorySSRSExt = new Rpt_RSQC_IPItemHistorySSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_IPItemHistorySSRSExt.Rpt_RSQC_IPItemHistorySSRSSp(begjob,
				endjob,
				begsuffix,
				endsuffix,
				begpsnum,
				endpsnum,
				begtdate,
				endtdate,
				PageBetweenItems,
				DisplayHeader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
