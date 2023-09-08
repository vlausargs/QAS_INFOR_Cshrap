//PROJECT NAME: ReportExt
//CLASS NAME: SLFixedAssetAcquisitionReport.cs

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
    [IDOExtensionClass("SLFixedAssetAcquisitionReport")]
    public class SLFixedAssetAcquisitionReport : ExtensionClassBase
    {
       

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_FixedAssetAcquisitionSp([Optional] DateTime? SAcqDate,
		                                             [Optional] DateTime? EAcqDate,
		                                             [Optional] string DeprCode,
		                                             [Optional] string FaType,
		                                             [Optional] string FaStat,
		                                             [Optional] string SFaNum,
		                                             [Optional] string EFaNum,
		                                             [Optional] string SFaClass,
		                                             [Optional] string EFaClass,
		                                             [Optional] string SLoc,
		                                             [Optional] string ELoc,
		                                             [Optional] string SVendNum,
		                                             [Optional] string EVendNum,
		                                             [Optional] short? SAcqDateOffset,
		                                             [Optional] short? EAcqDateOffset,
		                                             [Optional] byte? DisplayHeader,
		                                             [Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_FixedAssetAcquisitionExt = new Rpt_FixedAssetAcquisitionFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_FixedAssetAcquisitionExt.Rpt_FixedAssetAcquisitionSp(SAcqDate,
				                                                                       EAcqDate,
				                                                                       DeprCode,
				                                                                       FaType,
				                                                                       FaStat,
				                                                                       SFaNum,
				                                                                       EFaNum,
				                                                                       SFaClass,
				                                                                       EFaClass,
				                                                                       SLoc,
				                                                                       ELoc,
				                                                                       SVendNum,
				                                                                       EVendNum,
				                                                                       SAcqDateOffset,
				                                                                       EAcqDateOffset,
				                                                                       DisplayHeader,
				                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
