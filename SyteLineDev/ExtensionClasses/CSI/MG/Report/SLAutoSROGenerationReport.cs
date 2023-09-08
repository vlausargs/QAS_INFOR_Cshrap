//PROJECT NAME: ReportExt
//CLASS NAME: SLAutoSROGenerationReport.cs

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
	[IDOExtensionClass("SLAutoSROGenerationReport")]
	public class SLAutoSROGenerationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_AutoSROGenSp(int? iCreateSROs,
		DateTime? iThroughDate,
		string iStartSerNum,
		string iEndSerNum,
		string iStartSroType,
		string iEndSroType,
		string iStartDept,
		string iEndDept,
		string iStartWc,
		string iEndWc,
		int? iKeepOperNums,
		int? iDateOffset,
		[Optional] string pSite,
		[Optional] decimal? UserID)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_AutoSROGenExt = new SSSFSRpt_AutoSROGenFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_AutoSROGenExt.SSSFSRpt_AutoSROGenSp(iCreateSROs,
				iThroughDate,
				iStartSerNum,
				iEndSerNum,
				iStartSroType,
				iEndSroType,
				iStartDept,
				iEndDept,
				iStartWc,
				iEndWc,
				iKeepOperNums,
				iDateOffset,
				pSite,
				UserID);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
