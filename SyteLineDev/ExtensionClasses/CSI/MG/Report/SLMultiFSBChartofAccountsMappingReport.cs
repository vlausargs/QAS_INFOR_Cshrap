//PROJECT NAME: ReportExt
//CLASS NAME: SLMultiFSBChartofAccountsMappingReport.cs

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
    [IDOExtensionClass("SLMultiFSBChartofAccountsMappingReport")]
    public class SLMultiFSBChartofAccountsMappingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_MultiFSBChartofAccountMappingSp([Optional] string AccountStarting,
		[Optional] string AccountEnding,
		[Optional] string ExOptacChartType,
		[Optional] int? DisplayHeader,
		[Optional] string SortByTrx,
		[Optional] string Name,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_MultiFSBChartofAccountMappingExt = new Rpt_MultiFSBChartofAccountMappingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_MultiFSBChartofAccountMappingExt.Rpt_MultiFSBChartofAccountMappingSp(AccountStarting,
				AccountEnding,
				ExOptacChartType,
				DisplayHeader,
				SortByTrx,
				Name,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
