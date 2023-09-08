//PROJECT NAME: ReportExt
//CLASS NAME: SLServiceOrderWIPValuationReport.cs

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
	[IDOExtensionClass("SLServiceOrderWIPValuationReport")]
	public class SLServiceOrderWIPValuationReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSRpt_SROWIPValuationSp([Optional] string BegProductCode,
		[Optional] string EndProductCode,
		[Optional] string BegItem,
		[Optional] string EndItem,
		[Optional] string BegSroNum,
		[Optional] string EndSroNum,
		[Optional] int? BegSroLine,
		[Optional] int? EndSroLine,
		[Optional] int? BegSroOper,
		[Optional] int? EndSroOper,
		[Optional] string BegOperCode,
		[Optional] string EndOperCode,
		[Optional] DateTime? BegOpenDate,
		[Optional] DateTime? EndOpenDate,
		[Optional] string BegSroType,
		[Optional] string EndSroType,
		[Optional, DefaultParameterValue(1)] int? InclOpen,
		[Optional, DefaultParameterValue(1)] int? InclInvoice,
		[Optional, DefaultParameterValue(0)] int? InclDetail,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSRpt_SROWIPValuationExt = new SSSFSRpt_SROWIPValuationFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSRpt_SROWIPValuationExt.SSSFSRpt_SROWIPValuationSp(BegProductCode,
				EndProductCode,
				BegItem,
				EndItem,
				BegSroNum,
				EndSroNum,
				BegSroLine,
				EndSroLine,
				BegSroOper,
				EndSroOper,
				BegOperCode,
				EndOperCode,
				BegOpenDate,
				EndOpenDate,
				BegSroType,
				EndSroType,
				InclOpen,
				InclInvoice,
				InclDetail,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
