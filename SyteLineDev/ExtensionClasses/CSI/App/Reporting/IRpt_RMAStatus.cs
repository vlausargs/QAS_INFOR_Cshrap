//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RMAStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RMAStatus
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMAStatusSp(string RMAStatus = "OSCHR",
		string RMALineStatus = "OFCH",
		int? PrintExternalNotes = 0,
		int? PrintInternalNotes = 0,
		int? TranslateToDomesticCurrency = 0,
		int? ToBeCredited = 0,
		string SortBy = "R",
		string RMAStarting = null,
		string RMAEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string WhseStarting = null,
		string WhseEnding = null,
		DateTime? RMADateStarting = null,
		DateTime? RMADateEnding = null,
		string ProblemCodeStarting = null,
		string ProblemCodeEnding = null,
		int? RMALineStarting = null,
		int? RMALineEnding = null,
		string RMAItemStarting = null,
		string RMAItemEnding = null,
		string EvaluationStarting = null,
		string EvaluationEnding = null,
		string DispositionStarting = null,
		string DispositionEnding = null,
		int? RMADateStartingOffset = null,
		int? RMADateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

