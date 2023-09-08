//PROJECT NAME: ReportExt
//CLASS NAME: SLBarcodedResourcesReport.cs

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
    [IDOExtensionClass("SLBarcodedResourcesReport")]
    public class SLBarcodedResourcesReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BarcodedResourcesSp([Optional, DefaultParameterValue(2)] int? LabelSets,
		[Optional] string ResourceGroupStarting,
		[Optional] string ResourceGroupEnding,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BarcodedResourcesExt = new Rpt_BarcodedResourcesFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BarcodedResourcesExt.Rpt_BarcodedResourcesSp(LabelSets,
				                                                               ResourceGroupStarting,
				                                                               ResourceGroupEnding,
				                                                               pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
