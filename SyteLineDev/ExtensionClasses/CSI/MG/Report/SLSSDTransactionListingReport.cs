//PROJECT NAME: ReportExt
//CLASS NAME: SLSSDTransactionListingReport.cs

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
    [IDOExtensionClass("SLSSDTransactionListingReport")]
    public class SLSSDTransactionListingReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_SSDTransactionListingSp([Optional] DateTime? PeriodStarting,
		[Optional] DateTime? PeriodEnding,
		[Optional] string ExOptszTransIndicator,
		[Optional] string ExOptszSsdRefType,
		[Optional] int? ExOptszSortByTransaction,
		[Optional] string CustomerStarting,
		[Optional] string CustomerEnding,
		[Optional] string VendorStarting,
		[Optional] string VendorEnding,
		[Optional] string WhseStarting,
		[Optional] string WhseEnding,
		[Optional] int? PeriodStartingOffset,
		[Optional] int? PeriodEndingOffset,
		[Optional] int? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iRpt_SSDTransactionListingExt = new Rpt_SSDTransactionListingFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iRpt_SSDTransactionListingExt.Rpt_SSDTransactionListingSp(PeriodStarting,
				PeriodEnding,
				ExOptszTransIndicator,
				ExOptszSsdRefType,
				ExOptszSortByTransaction,
				CustomerStarting,
				CustomerEnding,
				VendorStarting,
				VendorEnding,
				WhseStarting,
				WhseEnding,
				PeriodStartingOffset,
				PeriodEndingOffset,
				DisplayHeader,
				pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
