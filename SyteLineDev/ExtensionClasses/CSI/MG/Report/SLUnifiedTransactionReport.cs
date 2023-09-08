//PROJECT NAME: ReportExt
//CLASS NAME: SLUnifiedTransactionReport.cs

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
	[IDOExtensionClass("SLUnifiedTransactionReport")]
	public class SLUnifiedTransactionReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_UnifiedTransactionSp(string beg_partner_id,
		DateTime? beg_trans_date,
		string beg_sro_num,
		string end_partner_id,
		DateTime? end_trans_date,
		string end_sro_num,
		string RefType,
		int? IncludeMaterial,
		int? IncludeMaterialNotes,
		int? IncludeLabor,
		int? IncludeLaborNotes,
		int? IncludeMisc,
		int? IncludeMiscNotes,
		int? PageBreak,
		int? ShowPosted,
		int? ShowUnPosted,
		int? ShowInternal,
		int? ShowExternal,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_UnifiedTransactionExt = new SSSFSRpt_UnifiedTransactionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_UnifiedTransactionExt.SSSFSRpt_UnifiedTransactionSp(beg_partner_id,
				beg_trans_date,
				beg_sro_num,
				end_partner_id,
				end_trans_date,
				end_sro_num,
				RefType,
				IncludeMaterial,
				IncludeMaterialNotes,
				IncludeLabor,
				IncludeLaborNotes,
				IncludeMisc,
				IncludeMiscNotes,
				PageBreak,
				ShowPosted,
				ShowUnPosted,
				ShowInternal,
				ShowExternal,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
