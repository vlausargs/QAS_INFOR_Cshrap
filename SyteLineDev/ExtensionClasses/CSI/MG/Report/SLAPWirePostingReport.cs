//PROJECT NAME: ReportExt
//CLASS NAME: SLAPWirePostingReport.cs

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
    [IDOExtensionClass("SLAPWirePostingReport")]
    public class SLAPWirePostingReport : ExtensionClassBase
    {
        
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_APWirePostingSP([Optional] string PaymentType,
		                                     [Optional] string BankCode,
		                                     [Optional] byte? DisplayDistDetail,
		                                     [Optional] string VendorStarting,
		                                     [Optional] string VendorEnding,
		                                     [Optional] byte? DisplayHeader,
		                                     [Optional] DateTime? PayDateStarting,
		                                     [Optional] DateTime? PayDateEnding,
		                                     [Optional] string SessionIDChar,
		                                     [Optional, DefaultParameterValue("Number")] string PSortNameNum,
		[Optional] int? TaskId,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_APWirePostingExt = new Rpt_APWirePostingFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_APWirePostingExt.Rpt_APWirePostingSP(PaymentType,
				                                                       BankCode,
				                                                       DisplayDistDetail,
				                                                       VendorStarting,
				                                                       VendorEnding,
				                                                       DisplayHeader,
				                                                       PayDateStarting,
				                                                       PayDateEnding,
				                                                       SessionIDChar,
				                                                       PSortNameNum,
				                                                       TaskId,
				                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
