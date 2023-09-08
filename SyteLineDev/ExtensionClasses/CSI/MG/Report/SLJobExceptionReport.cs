//PROJECT NAME: ReportExt
//CLASS NAME: SLJobExceptionReport.cs

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
    [IDOExtensionClass("SLJobExceptionReport")]
    public class SLJobExceptionReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobExceptionSp([Optional] string StartJob,
		[Optional] string EndJob,
		[Optional] int? SSuffix,
		[Optional] int? ESuffix,
		[Optional] string Status,
		[Optional] decimal? TolFactor,
		[Optional] int? ShowDetail,
		[Optional] string DispJobTol,
		[Optional] string StartItem,
		[Optional] string EndItem,
		[Optional] string SCustNum,
		[Optional] string ECustNum,
		[Optional] string StartProdMix,
		[Optional] string EndProdMix,
		[Optional] string OrdType,
		[Optional] string SOrdNum,
		[Optional] string EOrdNum,
		[Optional] DateTime? SLstTrxDate,
		[Optional] DateTime? ELstTrxDate,
		[Optional] DateTime? StartJobDate,
		[Optional] DateTime? EndJobDate,
		[Optional] int? SLstTrxDateOffSET,
		[Optional] int? ELstTrxDateOffSET,
		[Optional] int? SJobDateOffSET,
		[Optional] int? EJobDateOffSET,
		[Optional] int? DisplayHeader,
		[Optional] string pSite,
		[Optional] string BGUser)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_JobExceptionExt = new Rpt_JobExceptionFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_JobExceptionExt.Rpt_JobExceptionSp(StartJob,
				EndJob,
				SSuffix,
				ESuffix,
				Status,
				TolFactor,
				ShowDetail,
				DispJobTol,
				StartItem,
				EndItem,
				SCustNum,
				ECustNum,
				StartProdMix,
				EndProdMix,
				OrdType,
				SOrdNum,
				EOrdNum,
				SLstTrxDate,
				ELstTrxDate,
				StartJobDate,
				EndJobDate,
				SLstTrxDateOffSET,
				ELstTrxDateOffSET,
				SJobDateOffSET,
				EJobDateOffSET,
				DisplayHeader,
				pSite,
				BGUser);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
