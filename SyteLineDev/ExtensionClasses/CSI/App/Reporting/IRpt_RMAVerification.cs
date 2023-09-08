//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RMAVerification.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RMAVerification
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMAVerificationSp(string PStartingRMA = null,
		string PEndingRMA = null,
		string PStatus = "OS",
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingWhse = null,
		string PEndingWhse = null,
		DateTime? PStartingRMADate = null,
		DateTime? PEndingRMADate = null,
		int? PStartingRMALine = null,
		int? PEndingRMALine = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintItemOverview = 0,
		int? PrintRMATable = 1,
		int? PrintRMAItemTable = 1,
		int? PrintReasonText = 0,
		int? PStartingRMADateOffset = null,
		int? PEndingRMADateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

