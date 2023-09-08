//PROJECT NAME: ReportExt
//CLASS NAME: SLProductionExceptionsReport.cs

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
    [IDOExtensionClass("SLProductionExceptionsReport")]
    public class SLProductionExceptionsReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ProductionExceptionsSp([Optional] string ScheduleType,
		[Optional] string SJob,
		[Optional] string EJob,
		[Optional] int? SSuffix,
		[Optional] int? ESuffix,
		[Optional] string SItem,
		[Optional] string EItem,
		[Optional] decimal? SDaysLate,
		[Optional] decimal? EDaysLate,
		[Optional] int? ShowDetail,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ProductionExceptionsExt = new Rpt_ProductionExceptionsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ProductionExceptionsExt.Rpt_ProductionExceptionsSp(ScheduleType,
				SJob,
				EJob,
				SSuffix,
				ESuffix,
				SItem,
				EItem,
				SDaysLate,
				EDaysLate,
				ShowDetail,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
