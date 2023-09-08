//PROJECT NAME: ReportExt
//CLASS NAME: SLGSTInvoicedReport.cs

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
    [IDOExtensionClass("SLGSTInvoicedReport")]
    public class SLGSTInvoicedReport : ExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_GSTInvoicedSp([Optional] DateTime? StartingDate,
		                                   [Optional] DateTime? EndingDate,
		                                   [Optional] short? StartingDateOffset,
		                                   [Optional] short? EndingDateOffset,
		                                   [Optional] byte? DisplayHeader,
		                                   [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_GSTInvoicedExt = new Rpt_GSTInvoicedFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_GSTInvoicedExt.Rpt_GSTInvoicedSp(StartingDate,
				                                                   EndingDate,
				                                                   StartingDateOffset,
				                                                   EndingDateOffset,
				                                                   DisplayHeader,
				                                                   pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
