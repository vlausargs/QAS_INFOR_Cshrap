//PROJECT NAME: ReportExt
//CLASS NAME: SLPSTInputTaxCreditReport.cs

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
    [IDOExtensionClass("SLPSTInputTaxCreditReport")]
    public class SLPSTInputTaxCreditReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_PSTInputTaxCreditSp([Optional] int? TaxSystem,
		[Optional] string TaxCode,
		[Optional] DateTime? TaxDateStarting,
		[Optional] DateTime? TaxDateEnding,
		[Optional] int? TaxDateStartingOffset,
		[Optional] int? TaxDateEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_PSTInputTaxCreditExt = new Rpt_PSTInputTaxCreditFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_PSTInputTaxCreditExt.Rpt_PSTInputTaxCreditSp(TaxSystem,
				TaxCode,
				TaxDateStarting,
				TaxDateEnding,
				TaxDateStartingOffset,
				TaxDateEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
