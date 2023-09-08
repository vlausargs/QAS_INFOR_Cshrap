//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetDisposalTransactionReport.cs

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
    [IDOExtensionClass("SLFixedAssetDisposalTransactionReport")]
    public class SLFixedAssetDisposalTransactionReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FixedAssetDisposalTransactionSp([Optional] DateTime? StartingDisposeDate,
		                                                     [Optional] DateTime? EndingDisposeDate,
		                                                     [Optional] short? StartingDisposeDateOffset,
		                                                     [Optional] short? EndingDisposeDateOffset,
		                                                     [Optional] string StartingFanum,
		                                                     [Optional] string EndingFanum,
		                                                     [Optional] byte? DisplayHeader,
		                                                     [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_FixedAssetDisposalTransactionExt = new Rpt_FixedAssetDisposalTransactionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_FixedAssetDisposalTransactionExt.Rpt_FixedAssetDisposalTransactionSp(StartingDisposeDate,
				                                                                                       EndingDisposeDate,
				                                                                                       StartingDisposeDateOffset,
				                                                                                       EndingDisposeDateOffset,
				                                                                                       StartingFanum,
				                                                                                       EndingFanum,
				                                                                                       DisplayHeader,
				                                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
