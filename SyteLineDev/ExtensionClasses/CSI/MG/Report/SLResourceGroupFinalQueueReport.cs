//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceGroupFinalQueueReport.cs

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
    [IDOExtensionClass("SLResourceGroupFinalQueueReport")]
    public class SLResourceGroupFinalQueueReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceGroupFinalQueueSp([Optional] string ResourceStarting,
		[Optional] string ResourceEnding,
		[Optional] string ResourceGroupStarting,
		[Optional] string ResourceGroupEnding,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceGroupFinalQueueExt = new Rpt_ResourceGroupFinalQueueFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceGroupFinalQueueExt.Rpt_ResourceGroupFinalQueueSp(ResourceStarting,
				ResourceEnding,
				ResourceGroupStarting,
				ResourceGroupEnding,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
