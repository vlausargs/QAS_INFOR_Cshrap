//PROJECT NAME: ReportExt
//CLASS NAME: SLResourceDispatchListReport.cs

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
    [IDOExtensionClass("SLResourceDispatchListReport")]
    public class SLResourceDispatchListReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ResourceDispatchListSp([Optional] string ResourceGroupType,
		[Optional] string ResourceStarting,
		[Optional] string ResourceEnding,
		[Optional] string ResourceGroupStarting,
		[Optional] string ResourceGroupEnding,
		[Optional] string ResourceTypeStarting,
		[Optional] string ResourceTypeEnding,
		[Optional] DateTime? ScheduleDateStarting,
		[Optional] DateTime? ScheduleDateEnding,
		[Optional] int? ScheduleDateStartingOffset,
		[Optional] int? ScheduleDateEndingOffset,
		[Optional, DefaultParameterValue(1)] int? ShowDateTime,
		[Optional, DefaultParameterValue(1)] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ResourceDispatchListExt = new Rpt_ResourceDispatchListFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ResourceDispatchListExt.Rpt_ResourceDispatchListSp(ResourceGroupType,
				ResourceStarting,
				ResourceEnding,
				ResourceGroupStarting,
				ResourceGroupEnding,
				ResourceTypeStarting,
				ResourceTypeEnding,
				ScheduleDateStarting,
				ScheduleDateEnding,
				ScheduleDateStartingOffset,
				ScheduleDateEndingOffset,
				ShowDateTime,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
