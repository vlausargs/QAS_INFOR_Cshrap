//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetClassificationReport.cs

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
    [IDOExtensionClass("SLFixedAssetClassificationReport")]
    public class SLFixedAssetClassificationReport : ExtensionClassBase
    {
       
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FixedAssetClassificationSp([Optional] string ClassCodeStarting,
		                                                [Optional] string ClassCodeEnding,
		                                                [Optional] string ExOptdfFaType,
		                                                [Optional] string ExOptdfFaStat,
		                                                [Optional] string AssetStarting,
		                                                [Optional] string AssetEnding,
		                                                [Optional] string VendorStarting,
		                                                [Optional] string VendorEnding,
		                                                [Optional] string LocationStarting,
		                                                [Optional] string LocationEnding,
		                                                [Optional] string DepartmentStarting,
		                                                [Optional] string DepartmentEnding,
		                                                [Optional] string SortBy,
		                                                [Optional] byte? DisplayHeader,
		                                                [Optional] string DeprCode2,
		                                                [Optional] string DeprCode3,
		                                                [Optional] string DeprCode4,
		                                                [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_FixedAssetClassificationExt = new Rpt_FixedAssetClassificationFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_FixedAssetClassificationExt.Rpt_FixedAssetClassificationSp(ClassCodeStarting,
				                                                                             ClassCodeEnding,
				                                                                             ExOptdfFaType,
				                                                                             ExOptdfFaStat,
				                                                                             AssetStarting,
				                                                                             AssetEnding,
				                                                                             VendorStarting,
				                                                                             VendorEnding,
				                                                                             LocationStarting,
				                                                                             LocationEnding,
				                                                                             DepartmentStarting,
				                                                                             DepartmentEnding,
				                                                                             SortBy,
				                                                                             DisplayHeader,
				                                                                             DeprCode2,
				                                                                             DeprCode3,
				                                                                             DeprCode4,
				                                                                             pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
