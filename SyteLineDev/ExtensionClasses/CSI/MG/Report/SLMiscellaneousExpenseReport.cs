//PROJECT NAME: ReportExt
//CLASS NAME: SLMiscellaneousExpenseReport.cs

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
	[IDOExtensionClass("SLMiscellaneousExpenseReport")]
	public class SLMiscellaneousExpenseReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_MiscExpSp(string _iPartnerStart,
		string _iPartnerEnd,
		DateTime? _iTransDateStart,
		DateTime? _iTransDateEnd,
		[Optional] int? _iTransDateStart_OffSET,
		[Optional] int? _iTransDateEnd_OffSET,
		string _iSroNumStart,
		string _iSroNumEnd,
		int? _iSROLineStart,
		int? _iSROLineEnd,
		int? _iSroOperStart,
		int? _iSroOperEnd,
		string _iPayTypeStart,
		string _iPayTypeEnd,
		string _iMiscCodeStart,
		string _iMiscCodeEnd,
		string _iShowStat,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_MiscExpExt = new SSSFSRpt_MiscExpFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_MiscExpExt.SSSFSRpt_MiscExpSp(_iPartnerStart,
				_iPartnerEnd,
				_iTransDateStart,
				_iTransDateEnd,
				_iTransDateStart_OffSET,
				_iTransDateEnd_OffSET,
				_iSroNumStart,
				_iSroNumEnd,
				_iSROLineStart,
				_iSROLineEnd,
				_iSroOperStart,
				_iSroOperEnd,
				_iPayTypeStart,
				_iPayTypeEnd,
				_iMiscCodeStart,
				_iMiscCodeEnd,
				_iShowStat,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
