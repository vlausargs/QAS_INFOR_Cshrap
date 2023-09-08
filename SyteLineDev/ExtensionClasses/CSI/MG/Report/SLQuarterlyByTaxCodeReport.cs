//PROJECT NAME: ReportExt
//CLASS NAME: SLQuarterlyByTaxCodeReport.cs

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
    [IDOExtensionClass("SLQuarterlyByTaxCodeReport")]
    public class SLQuarterlyByTaxCodeReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_QuarterlybyTaxCodeSp([Optional] DateTime? CheckDateStarting,
		[Optional] DateTime? CheckDateEnding,
		[Optional] string TaxCodeStarting,
		[Optional] string TaxCodeEnding,
		[Optional] int? CheckDateStartingOffset,
		[Optional] int? CheckDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] int? EmpTypeHourlyPerm,
		[Optional] int? EmpTypeSalaryPerm,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_QuarterlybyTaxCodeExt = new Rpt_QuarterlybyTaxCodeFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_QuarterlybyTaxCodeExt.Rpt_QuarterlybyTaxCodeSp(CheckDateStarting,
				CheckDateEnding,
				TaxCodeStarting,
				TaxCodeEnding,
				CheckDateStartingOffset,
				CheckDateEndingOffset,
				DisplayHeader,
				EmpTypeHourlyPerm,
				EmpTypeSalaryPerm,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
