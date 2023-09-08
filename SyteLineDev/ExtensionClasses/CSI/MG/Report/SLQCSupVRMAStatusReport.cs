//PROJECT NAME: ReportExt
//CLASS NAME: SLQCSupVRMAStatusReport.cs

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
    [IDOExtensionClass("SLQCSupVRMAStatusReport")]
    public class SLQCSupVRMAStatusReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_RSQC_SupVRMAStatusSSRSSp([Optional] string begitem,
		[Optional] string enditem,
		[Optional] string begvend,
		[Optional] string endvend,
		[Optional] DateTime? begcdate,
		[Optional] DateTime? endcdate,
		[Optional] string sortby,
		[Optional] int? displayheader,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_RSQC_SupVRMAStatusSSRSExt = new Rpt_RSQC_SupVRMAStatusSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_RSQC_SupVRMAStatusSSRSExt.Rpt_RSQC_SupVRMAStatusSSRSSp(begitem,
				enditem,
				begvend,
				endvend,
				begcdate,
				endcdate,
				sortby,
				displayheader,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
