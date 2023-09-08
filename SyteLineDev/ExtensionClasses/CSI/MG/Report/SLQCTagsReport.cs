//PROJECT NAME: ReportExt
//CLASS NAME: SLQCTagsReport.cs

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
	[IDOExtensionClass("SLQCTagsReport")]
	public class SLQCTagsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable RSQC_PrintTagsSSRSSp(int? i_rcvrnum,
		string i_item,
		string i_itmdesc,
		string i_reftype,
		string i_entity,
		string i_entityname,
		string i_insp,
		string i_inspname,
		DateTime? i_inspdate,
		string i_refnum,
		int? i_refline,
		int? i_refrel,
		decimal? i_acceptqty,
		string i_a_reason,
		string i_a_reason_descr,
		string i_a_dcode,
		string i_a_dcode_descr,
		int? i_accepttags,
		int? i_acceptnum,
		decimal? i_rejectqty,
		string i_r_reason,
		string i_r_reason_descr,
		string i_r_dcode,
		string i_r_dcode_descr,
		string i_r_cause,
		string i_r_cause_descr,
		int? i_rejecttags,
		int? i_rejectnum,
		decimal? i_holdqty,
		string i_h_reason,
		string i_h_reason_descr,
		int? i_holdtags,
		int? i_holdnum,
		string i_lot,
		string i_psnum,
		string i_wcdescr,
		string psite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRSQC_PrintTagsSSRSExt = new RSQC_PrintTagsSSRSFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRSQC_PrintTagsSSRSExt.RSQC_PrintTagsSSRSSp(i_rcvrnum,
				i_item,
				i_itmdesc,
				i_reftype,
				i_entity,
				i_entityname,
				i_insp,
				i_inspname,
				i_inspdate,
				i_refnum,
				i_refline,
				i_refrel,
				i_acceptqty,
				i_a_reason,
				i_a_reason_descr,
				i_a_dcode,
				i_a_dcode_descr,
				i_accepttags,
				i_acceptnum,
				i_rejectqty,
				i_r_reason,
				i_r_reason_descr,
				i_r_dcode,
				i_r_dcode_descr,
				i_r_cause,
				i_r_cause_descr,
				i_rejecttags,
				i_rejectnum,
				i_holdqty,
				i_h_reason,
				i_h_reason_descr,
				i_holdtags,
				i_holdnum,
				i_lot,
				i_psnum,
				i_wcdescr,
				psite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
