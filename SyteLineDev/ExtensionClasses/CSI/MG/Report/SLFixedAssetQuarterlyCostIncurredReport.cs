//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetQuarterlyCostIncurredReport.cs

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
    [IDOExtensionClass("SLFixedAssetQuarterlyCostIncurredReport")]
    public class SLFixedAssetQuarterlyCostIncurredReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FixedAssetQuarterlyCostIncurredSp([Optional] int? ReportYear,
		                                                       [Optional, DefaultParameterValue("R")] string AssetTypes,
		[Optional, DefaultParameterValue("A")] string StatusCodes,
		[Optional] string StartAssetNum,
		[Optional] string EndAssetNum,
		[Optional] string StartClassCode,
		[Optional] string EndClassCode,
		[Optional] string StartDept,
		[Optional] string EndDept,
		[Optional] byte? DisplayHeader,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_FixedAssetQuarterlyCostIncurredExt = new Rpt_FixedAssetQuarterlyCostIncurredFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_FixedAssetQuarterlyCostIncurredExt.Rpt_FixedAssetQuarterlyCostIncurredSp(ReportYear,
				                                                                                           AssetTypes,
				                                                                                           StatusCodes,
				                                                                                           StartAssetNum,
				                                                                                           EndAssetNum,
				                                                                                           StartClassCode,
				                                                                                           EndClassCode,
				                                                                                           StartDept,
				                                                                                           EndDept,
				                                                                                           DisplayHeader,
				                                                                                           pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
