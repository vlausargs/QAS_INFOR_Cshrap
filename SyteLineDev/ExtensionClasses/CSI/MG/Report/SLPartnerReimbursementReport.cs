//PROJECT NAME: ReportExt
//CLASS NAME: SLPartnerReimbursementReport.cs

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
	[IDOExtensionClass("SLPartnerReimbursementReport")]
	public class SLPartnerReimbursementReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_PartReimbSp(string _iPartnerStart,
		string _iPartnerEnd,
		string _iSroNumStart,
		string _iSroNumEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		[Optional] int? _iTransDateStart_OffSET,
		[Optional] int? _iTransDateEnd_OffSET,
		string _iReimbStat,
		string _iBatchNum,
		string _iReimbMethod,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_PartReimbExt = new SSSFSRpt_PartReimbFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_PartReimbExt.SSSFSRpt_PartReimbSp(_iPartnerStart,
				_iPartnerEnd,
				_iSroNumStart,
				_iSroNumEnd,
				_iTransDateStart,
				_iTransDateEnd,
				_iTransDateStart_OffSET,
				_iTransDateEnd_OffSET,
				_iReimbStat,
				_iBatchNum,
				_iReimbMethod,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
