//PROJECT NAME: Reporting
//CLASS NAME: IRpt_EstimateWorksheet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_EstimateWorksheet
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_EstimateWorksheetSp(string EstimateStatus = "WQPH",
		string EstimateStarting = null,
		string EstimateEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		DateTime? QuoteDateStarting = null,
		DateTime? QuoteDateEnding = null,
		int? QuoteDateStartingOffset = null,
		int? QuoteDateEndingOffset = null,
		DateTime? ExpireDateStarting = null,
		DateTime? ExpireDateEnding = null,
		int? ExpireDateStartingOffset = null,
		int? ExpireDateEndingOffset = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustItemStarting = null,
		string CustItemEnding = null,
		DateTime? DueDateStarting = null,
		DateTime? DueDateEnding = null,
		int? DueDateStartingOffset = null,
		int? DueDateEndingOffset = null,
		int? CoitemShowInternal = 1,
		int? CoitemShowExternal = 1,
		int? DisplayHeader = 0,
		string StartProspect = null,
		string EndProspect = null,
		string pSite = null);
	}
}

