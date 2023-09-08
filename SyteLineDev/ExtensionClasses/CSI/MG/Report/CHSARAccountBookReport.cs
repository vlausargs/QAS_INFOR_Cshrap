//PROJECT NAME: ReportExt
//CLASS NAME: CHSARAccountBookReport.cs

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
    [IDOExtensionClass("CHSARAccountBookReport")]
    public class CHSARAccountBookReport : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CHSRpt_ARAccountBookSp(string BegCustNum,
		                                        string EndCustNum,
		                                        DateTime? BegDate,
		                                        DateTime? EndDate,
		                                        string CurrencyCode,
		                                        byte? ViewDetailStats,
		                                        [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iCHSRpt_ARAccountBookExt = new CHSRpt_ARAccountBookFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iCHSRpt_ARAccountBookExt.CHSRpt_ARAccountBookSp(BegCustNum,
				                                                             EndCustNum,
				                                                             BegDate,
				                                                             EndDate,
				                                                             CurrencyCode,
				                                                             ViewDetailStats,
				                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
