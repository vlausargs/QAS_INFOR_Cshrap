//PROJECT NAME: ReportExt
//CLASS NAME: SLTaxInvoicedParametricReport.cs

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
    [IDOExtensionClass("SLTaxInvoicedParametricReport")]
    public class SLTaxInvoicedParametricReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_TaxInvoicedParametricSP([Optional] int? taxsystem,
		[Optional] string taxjur,
		[Optional] DateTime? Begininvstaxinvdate,
		[Optional] DateTime? Endinvstaxinvdate,
		[Optional] int? BegininvstaxinvdateOffset,
		[Optional] int? EndinvstaxinvdateOffset,
		[Optional] int? Showdetail,
		[Optional] int? DisplayHeader,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_TaxInvoicedParametricExt = new Rpt_TaxInvoicedParametricFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_TaxInvoicedParametricExt.Rpt_TaxInvoicedParametricSP(taxsystem,
				taxjur,
				Begininvstaxinvdate,
				Endinvstaxinvdate,
				BegininvstaxinvdateOffset,
				EndinvstaxinvdateOffset,
				Showdetail,
				DisplayHeader,
				TaskId,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
