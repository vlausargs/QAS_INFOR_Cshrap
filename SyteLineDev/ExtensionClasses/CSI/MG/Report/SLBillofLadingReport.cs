//PROJECT NAME: ReportExt
//CLASS NAME: SLBillofLadingReport.cs

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
    [IDOExtensionClass("SLBillofLadingReport")]
    public class SLBillofLadingReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_BillofLadingSp([Optional] string DOStarting,
		                                    [Optional] string DOEnding,
		                                    [Optional] string CustomerStarting,
		                                    [Optional] string CustomerEnding,
		                                    [Optional] int? CustSeqStarting,
		                                    [Optional] int? CustSeqEnding,
		                                    [Optional] DateTime? PickupDateStarting,
		                                    [Optional] DateTime? PickupDateEnding,
		                                    [Optional] short? PickupDateStartingOffset,
		                                    [Optional] short? PickupDateEndingOffset,
		                                    [Optional] byte? DisplayHeader,
		                                    [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_BillofLadingExt = new Rpt_BillofLadingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_BillofLadingExt.Rpt_BillofLadingSp(DOStarting,
				                                                     DOEnding,
				                                                     CustomerStarting,
				                                                     CustomerEnding,
				                                                     CustSeqStarting,
				                                                     CustSeqEnding,
				                                                     PickupDateStarting,
				                                                     PickupDateEnding,
				                                                     PickupDateStartingOffset,
				                                                     PickupDateEndingOffset,
				                                                     DisplayHeader,
				                                                     pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
