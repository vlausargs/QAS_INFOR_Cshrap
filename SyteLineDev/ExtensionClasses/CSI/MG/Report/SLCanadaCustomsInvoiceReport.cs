//PROJECT NAME: ReportExt
//CLASS NAME: SLCanadaCustomsInvoiceReport.cs

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
    [IDOExtensionClass("SLCanadaCustomsInvoiceReport")]
    public class SLCanadaCustomsInvoiceReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_CanadaCustomsInvoiceSp([Optional] decimal? ShipmentStarting,
		                                            [Optional] decimal? ShipmentEnding,
		                                            [Optional] string CustomerStarting,
		                                            [Optional] string CustomerEnding,
		                                            [Optional] int? ShipToStarting,
		                                            [Optional] int? ShipToEnding,
		                                            [Optional] byte? DisplayHeader,
		                                            [Optional] string PrintItemCustItem,
		                                            [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_CanadaCustomsInvoiceExt = new Rpt_CanadaCustomsInvoiceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_CanadaCustomsInvoiceExt.Rpt_CanadaCustomsInvoiceSp(ShipmentStarting,
				                                                                     ShipmentEnding,
				                                                                     CustomerStarting,
				                                                                     CustomerEnding,
				                                                                     ShipToStarting,
				                                                                     ShipToEnding,
				                                                                     DisplayHeader,
				                                                                     PrintItemCustItem,
				                                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
