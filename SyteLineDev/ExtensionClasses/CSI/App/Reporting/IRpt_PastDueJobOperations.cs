//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PastDueJobOperations.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PastDueJobOperations
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueJobOperationsSp(string JobStarting = null,
		string JobEnding = null,
		int? JobSuffixStarting = null,
		int? JobSuffixEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string Ord_type = null,
		string RefStarting = null,
		string RefEnding = null,
		DateTime? LastTrxDateStarting = null,
		DateTime? LastTrxDateEnding = null,
		int? LastTrxDateStartingOffset = null,
		int? LastTrxDateEndingOffset = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		DateTime? PastDueDate = null,
		int? PastDueOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

