//PROJECT NAME: ReportExt
//CLASS NAME: SLQCReceiptTagsReport.cs

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
	[IDOExtensionClass("SLQCReceiptTagsReport")]
	public class SLQCReceiptTagsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RSQC_PrintReceiptTagSSRSsp(int? i_RcvrNum,
		DateTime? i_TransDate,
		string i_UserCode,
		decimal? i_TagQty,
		string i_Stat,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_PrintReceiptTagSSRSExt = new RSQC_PrintReceiptTagSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_PrintReceiptTagSSRSExt.RSQC_PrintReceiptTagSSRSsp(i_RcvrNum,
				i_TransDate,
				i_UserCode,
				i_TagQty,
				i_Stat,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
