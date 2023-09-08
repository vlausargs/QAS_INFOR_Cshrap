//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderOnHoldReport.cs

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
	[IDOExtensionClass("SLServiceOrderOnHoldReport")]
	public class SLServiceOrderOnHoldReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROOnHoldSp(DateTime? beg_trans_date,
		DateTime? end_trans_date,
		string beg_sro_num,
		string end_sro_num,
		int? beg_sro_line,
		int? end_sro_line,
		int? beg_sro_oper,
		int? end_sro_oper,
		string beg_cust_num,
		string end_cust_num,
		int? t_page,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROOnHoldExt = new SSSFSRpt_SROOnHoldFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROOnHoldExt.SSSFSRpt_SROOnHoldSp(beg_trans_date,
				end_trans_date,
				beg_sro_num,
				end_sro_num,
				beg_sro_line,
				end_sro_line,
				beg_sro_oper,
				end_sro_oper,
				beg_cust_num,
				end_cust_num,
				t_page,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
