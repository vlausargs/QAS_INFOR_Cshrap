//PROJECT NAME: Data
//CLASS NAME: ISendReceivableTracker.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISendReceivableTracker
	{
		(int? ReturnCode,
			string Infobar) SendReceivableTrackerSp(
			string CustomerPartyID = null,
			string CheckNum = null,
			string BankCode = null,
			string Type = null,
			string CreditMemoNum = null,
			Guid? SessionID = null,
			string Infobar = null);
	}
}

