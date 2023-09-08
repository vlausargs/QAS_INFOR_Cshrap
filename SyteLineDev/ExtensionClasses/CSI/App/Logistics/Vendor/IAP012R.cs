//PROJECT NAME: Logistics
//CLASS NAME: IAP012R.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAP012R
	{
		(int? ReturnCode, int? RAppmtCnt,
		string Infobar) AP012RSP(Guid? PSessionID,
		int? PAddToExisting = 1,
		int? PManualOnly = 0,
		string PPayCode = null,
		string PBankCode = null,
		string PStartingVendNum = null,
		string PEndingVendNum = null,
		string PStartingVendName = null,
		string PEndingVendName = null,
		string PSortNameNum = "Number",
		int? RAppmtCnt = null,
		string Infobar = null,
		DateTime? PPayDateStarting = null,
		DateTime? PPayDateEnding = null);
	}
}

