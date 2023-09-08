//PROJECT NAME: ReportExt
//CLASS NAME: SLJobPickListReport.cs

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
    [IDOExtensionClass("SLJobPickListReport")]
    public class SLJobPickListReport : CSIExtensionClassBase
	{

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_JobPickListSp([Optional] string Job,
			[Optional] int? Suffix,
			[Optional] string Item,
			[Optional] string Whse,
			[Optional] DateTime? PostDate,
			[Optional] int? StartingOperNum,
			[Optional] int? EndingOperNum,
			[Optional] int? SortByLoc,
			[Optional] int? IncludeSerialNumbers,
			[Optional] int? ReprintPickListItems,
			[Optional] int? PostMaterialIssues,
			[Optional] int? PageBetweenOperations,
			[Optional] int? PrintSecondaryLocations,
			[Optional] int? ExtendByScrapFactor,
			[Optional] int? PrintBarCode,
			[Optional] int? DisplayHeader,
			[Optional] string PMessageLanguage,
			[Optional] int? TaskID,
			[Optional] decimal? UserID,
			[Optional] string BGSessionId,
			[Optional] string pSite)
		{
			var iRpt_JobPickListExt = new Rpt_JobPickListFactory().Create(this, true);

			var result = iRpt_JobPickListExt.Rpt_JobPickListSp(Job,
				Suffix,
				Item,
				Whse,
				PostDate,
				StartingOperNum,
				EndingOperNum,
				SortByLoc,
				IncludeSerialNumbers,
				ReprintPickListItems,
				PostMaterialIssues,
				PageBetweenOperations,
				PrintSecondaryLocations,
				ExtendByScrapFactor,
				PrintBarCode,
				DisplayHeader,
				PMessageLanguage,
				TaskID,
				UserID,
				BGSessionId,
				pSite);


			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
	}
}
