//PROJECT NAME: ReportExt
//CLASS NAME: SLGLVoucherReport.cs

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
    [IDOExtensionClass("SLGLVoucherReport")]
    public class SLGLVoucherReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GLVoucherSp(string GLVoucherStarting,
		                                 string GLVoucherEnding,
		                                 string JournalId,
		                                 [Optional, DefaultParameterValue((byte)0)] byte? Preview,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_GLVoucherExt = new Rpt_GLVoucherFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_GLVoucherExt.Rpt_GLVoucherSp(GLVoucherStarting,
				                                               GLVoucherEnding,
				                                               JournalId,
				                                               Preview,
				                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
