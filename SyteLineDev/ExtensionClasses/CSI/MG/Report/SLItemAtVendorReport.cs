//PROJECT NAME: ReportExt
//CLASS NAME: SLItemAtVendorReport.cs

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
    [IDOExtensionClass("SLItemAtVendorReport")]
    public class SLItemAtVendorReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSRMXRpt_ItemAtVendorSp(int? inc_ord_type,
		                                          string beg_vend_num,
		                                          string end_vend_num,
		                                          string beg_item,
		                                          string end_item,
		                                          string beg_ref_num,
		                                          string end_ref_num,
		                                          byte? page_per_vendor,
		                                          [Optional] string pSite,
		                                          [Optional] byte? PrintItemOverview)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iSSSRMXRpt_ItemAtVendorExt = new SSSRMXRpt_ItemAtVendorFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iSSSRMXRpt_ItemAtVendorExt.SSSRMXRpt_ItemAtVendorSp(inc_ord_type,
				                                                                 beg_vend_num,
				                                                                 end_vend_num,
				                                                                 beg_item,
				                                                                 end_item,
				                                                                 beg_ref_num,
				                                                                 end_ref_num,
				                                                                 page_per_vendor,
				                                                                 pSite,
				                                                                 PrintItemOverview);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
