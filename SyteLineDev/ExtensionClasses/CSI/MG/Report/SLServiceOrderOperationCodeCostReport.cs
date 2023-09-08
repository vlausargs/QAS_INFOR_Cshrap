//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderOperationCodeCostReport.cs

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
	[IDOExtensionClass("SLServiceOrderOperationCodeCostReport")]
	public class SLServiceOrderOperationCodeCostReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROOperationCodeCostSp([Optional] string beg_oper_code,
		[Optional] string end_oper_code,
		[Optional] string beg_sro_num,
		[Optional] string end_sro_num,
		[Optional] string beg_cust_num,
		[Optional] string end_cust_num,
		[Optional] string beg_ser_num,
		[Optional] string end_ser_num,
		[Optional] string beg_item,
		[Optional] string end_item,
		[Optional] DateTime? beg_open_date,
		[Optional] DateTime? end_open_date,
		[Optional] string beg_sro_type,
		[Optional] string end_sro_type,
		[Optional] DateTime? beg_trans_date,
		[Optional] DateTime? end_trans_date,
		[Optional, DefaultParameterValue(1)] int? InclOpen,
		[Optional, DefaultParameterValue(1)] int? InclClosed,
		[Optional, DefaultParameterValue(1)] int? show_sro_notes,
		[Optional, DefaultParameterValue(1)] int? show_oper_notes,
		[Optional, DefaultParameterValue(1)] int? exclude_0_oper,
		[Optional, DefaultParameterValue(1)] int? exclude_0_line,
		[Optional, DefaultParameterValue(1)] int? include_cost,
		[Optional, DefaultParameterValue(1)] int? t_page,
		[Optional, DefaultParameterValue(1)] int? Internal1,
		[Optional, DefaultParameterValue(1)] int? External1,
		[Optional, DefaultParameterValue(1)] int? Internal2,
		[Optional, DefaultParameterValue(1)] int? External2,
		[Optional] string BADInfobar,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROOperationCodeCostExt = new SSSFSRpt_SROOperationCodeCostFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROOperationCodeCostExt.SSSFSRpt_SROOperationCodeCostSp(beg_oper_code,
				end_oper_code,
				beg_sro_num,
				end_sro_num,
				beg_cust_num,
				end_cust_num,
				beg_ser_num,
				end_ser_num,
				beg_item,
				end_item,
				beg_open_date,
				end_open_date,
				beg_sro_type,
				end_sro_type,
				beg_trans_date,
				end_trans_date,
				InclOpen,
				InclClosed,
				show_sro_notes,
				show_oper_notes,
				exclude_0_oper,
				exclude_0_line,
				include_cost,
				t_page,
				Internal1,
				External1,
				Internal2,
				External2,
				BADInfobar,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
