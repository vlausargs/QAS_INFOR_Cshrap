//PROJECT NAME: ReportExt
//CLASS NAME: SLWarrantyExpirationReport.cs

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
	[IDOExtensionClass("SLWarrantyExpirationReport")]
	public class SLWarrantyExpirationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSrpt_WarrantyExpirationSp(string beg_Item,
		string end_Item,
		string beg_ChildItem,
		string end_ChildItem,
		DateTime? beg_warr_expire,
		DateTime? end_warr_expire,
		int? IncludeSub,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSrpt_WarrantyExpirationExt = new SSSFSrpt_WarrantyExpirationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSrpt_WarrantyExpirationExt.SSSFSrpt_WarrantyExpirationSp(beg_Item,
				end_Item,
				beg_ChildItem,
				end_ChildItem,
				beg_warr_expire,
				end_warr_expire,
				IncludeSub,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
