//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetTransferReport.cs

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
    [IDOExtensionClass("SLFixedAssetTransferReport")]
    public class SLFixedAssetTransferReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable rpt_FixedAssetTransfersp([Optional] string AssetType,
		                                          [Optional] string StatusCode,
		                                          [Optional] DateTime? TransDateStarting,
		                                          [Optional] DateTime? TransDateEnding,
		                                          [Optional] short? TransDateStartingOffset,
		                                          [Optional] short? TransDateEndingOffset,
		                                          [Optional] string AssetStarting,
		                                          [Optional] string AssetEnding,
		                                          [Optional] string ClassCodeStarting,
		                                          [Optional] string ClassCodeEnding,
		                                          [Optional] string DepartmentStarting,
		                                          [Optional] string DepartmentEnding,
		                                          [Optional] string LocationStarting,
		                                          [Optional] string LocationEnding,
		                                          [Optional] byte? DisplayHeader,
		                                          [Optional] Guid? ProcessID,
		                                          [Optional] string BGSessionId,
		                                          [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var irpt_FixedAssetTransferExt = new rpt_FixedAssetTransferFactory().Create(appDb, bunchedLoadCollection);
				
				var result = irpt_FixedAssetTransferExt.rpt_FixedAssetTransfersp(AssetType,
				                                                                 StatusCode,
				                                                                 TransDateStarting,
				                                                                 TransDateEnding,
				                                                                 TransDateStartingOffset,
				                                                                 TransDateEndingOffset,
				                                                                 AssetStarting,
				                                                                 AssetEnding,
				                                                                 ClassCodeStarting,
				                                                                 ClassCodeEnding,
				                                                                 DepartmentStarting,
				                                                                 DepartmentEnding,
				                                                                 LocationStarting,
				                                                                 LocationEnding,
				                                                                 DisplayHeader,
				                                                                 ProcessID,
				                                                                 BGSessionId,
				                                                                 pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
