//PROJECT NAME: ReportExt
//CLASS NAME: SLIndentedCurrentBillOfMaterialReport.cs

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
    [IDOExtensionClass("SLIndentedCurrentBillOfMaterialReport")]
    public class SLIndentedCurrentBillOfMaterialReport : ExtensionClassBase
    {
        

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_IndentedCurrentBillofMaterialSp([Optional] string StartingItem,
		                                                     [Optional] string EndingItem,
		                                                     [Optional] string StartingProCode,
		                                                     [Optional] string EndingProCode,
		                                                     [Optional] string StartingRevision,
		                                                     [Optional] string EndingRevision,
		                                                     [Optional, DefaultParameterValue((byte)0)] byte? IncludeRevision,
		[Optional] string MaterialType,
		[Optional] string Source,
		[Optional] string Stocked,
		[Optional] string ABCCode,
		[Optional] DateTime? EffectiveDate,
		[Optional] short? EffectiveDateOffset,
		[Optional] string PageJob,
		[Optional] byte? PrintLevelZero,
		[Optional] byte? DisplayRefer,
		[Optional] byte? DisplayHeader,
		[Optional] byte? PrintAlternateMaterials,
		[Optional] string pSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var iRpt_IndentedCurrentBillofMaterialExt = new Rpt_IndentedCurrentBillofMaterialFactory().Create(appDb, bunchedLoadCollection);
				
				var result = iRpt_IndentedCurrentBillofMaterialExt.Rpt_IndentedCurrentBillofMaterialSp(StartingItem,
				                                                                                       EndingItem,
				                                                                                       StartingProCode,
				                                                                                       EndingProCode,
				                                                                                       StartingRevision,
				                                                                                       EndingRevision,
				                                                                                       IncludeRevision,
				                                                                                       MaterialType,
				                                                                                       Source,
				                                                                                       Stocked,
				                                                                                       ABCCode,
				                                                                                       EffectiveDate,
				                                                                                       EffectiveDateOffset,
				                                                                                       PageJob,
				                                                                                       PrintLevelZero,
				                                                                                       DisplayRefer,
				                                                                                       DisplayHeader,
				                                                                                       PrintAlternateMaterials,
				                                                                                       pSite);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
