//PROJECT NAME: ReportExt
//CLASS NAME: SLInteractionsReport.cs

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
    [IDOExtensionClass("SLInteractionsReport")]
    public class SLInteractionsReport : CSIExtensionClassBase
    {

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable Rpt_InteractionsSp([Optional, DefaultParameterValue("C")] string InteractionType,
			[Optional] decimal? BegInteractionID,
			[Optional] decimal? EndInteractionID,
			[Optional] string BegRefnum,
			[Optional] string EndRefnum,
			[Optional] DateTime? Beginteraction_date,
			[Optional] DateTime? Endinteraction_date,
			[Optional] DateTime? Begfollow_date,
			[Optional] DateTime? Endfollow_date,
			[Optional] string Begentered_by,
			[Optional] string Endentered_by,
			[Optional] string Begsalesman,
			[Optional] string Endsalesman,
			[Optional] string Begcontact,
			[Optional] string Endcontact,
			[Optional] string Begtopic,
			[Optional] string Endtopic,
			[Optional] string CommStat,
			[Optional] string CommSort,
			[Optional] int? StartingTransDateOffset,
			[Optional] int? EndingTransDateOffset,
			[Optional] int? StartingfollowDateOffset,
			[Optional] int? EndingfollowDateOffset,
			[Optional, DefaultParameterValue(0)] int? ShowInternal,
			[Optional, DefaultParameterValue(0)] int? ShowExternal,
			[Optional, DefaultParameterValue(0)] int? DisplayHeader,
			[Optional] string pSite)
		{
			var iRpt_InteractionsExt = new Rpt_InteractionsFactory().Create(this, true);

			var result = iRpt_InteractionsExt.Rpt_InteractionsSp(InteractionType,
				BegInteractionID,
				EndInteractionID,
				BegRefnum,
				EndRefnum,
				Beginteraction_date,
				Endinteraction_date,
				Begfollow_date,
				Endfollow_date,
				Begentered_by,
				Endentered_by,
				Begsalesman,
				Endsalesman,
				Begcontact,
				Endcontact,
				Begtopic,
				Endtopic,
				CommStat,
				CommSort,
				StartingTransDateOffset,
				EndingTransDateOffset,
				StartingfollowDateOffset,
				EndingfollowDateOffset,
				ShowInternal,
				ShowExternal,
				DisplayHeader,
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
