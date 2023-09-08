//PROJECT NAME: ReportExt
//CLASS NAME: SLContainerContentsReport.cs

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
	[IDOExtensionClass("SLContainerContentsReport")]
	public class SLContainerContentsReport : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_ContainerContentsSp([Optional] string PWhseStarting,
		[Optional] string PWhseEnding,
		[Optional] string PLocationStarting,
		[Optional] string PLocationEnding,
		[Optional] string PContainerStarting,
		[Optional] string PContainerEnding,
		[Optional] string PItemStarting,
		[Optional] string PItemEnding,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_ContainerContentsExt = new Rpt_ContainerContentsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_ContainerContentsExt.Rpt_ContainerContentsSp(PWhseStarting,
				PWhseEnding,
				PLocationStarting,
				PLocationEnding,
				PContainerStarting,
				PContainerEnding,
				PItemStarting,
				PItemEnding,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
	}
}
