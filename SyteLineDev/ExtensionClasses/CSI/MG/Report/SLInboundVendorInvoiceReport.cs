//PROJECT NAME: ReportExt
//CLASS NAME: SLInboundVendorInvoiceReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Reporting;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.Report
{
    [IDOExtensionClass("SLInboundVendorInvoiceReport")]
    public class SLInboundVendorInvoiceReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InboundVendorInvoiceSP([Optional] string Begvendnum,
		                                            [Optional] string Endvendnum,
		                                            [Optional] string Begponum,
		                                            [Optional] string Endponum,
		                                            [Optional] DateTime? Begorderdate,
		                                            [Optional] DateTime? Endorderdate,
		                                            [Optional] short? BegorderdateOffset,
		                                            [Optional] short? EndorderdateOffset,
		                                            [Optional] string BegVendOrder,
		                                            [Optional] string EndVendOrder,
		                                            [Optional] string ExOptprPostedEmp,
		                                            [Optional] byte? ExOptszShowDetail,
		                                            [Optional] byte? ExOptszShowOnlyErrors,
		                                            [Optional] byte? DisplayHeader,
		                                            [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_InboundVendorInvoiceExt = new Rpt_InboundVendorInvoiceFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_InboundVendorInvoiceExt.Rpt_InboundVendorInvoiceSP(Begvendnum,
				                                                                     Endvendnum,
				                                                                     Begponum,
				                                                                     Endponum,
				                                                                     Begorderdate,
				                                                                     Endorderdate,
				                                                                     BegorderdateOffset,
				                                                                     EndorderdateOffset,
				                                                                     BegVendOrder,
				                                                                     EndVendOrder,
				                                                                     ExOptprPostedEmp,
				                                                                     ExOptszShowDetail,
				                                                                     ExOptszShowOnlyErrors,
				                                                                     DisplayHeader,
				                                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
