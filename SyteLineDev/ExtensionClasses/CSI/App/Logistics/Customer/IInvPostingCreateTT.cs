//PROJECT NAME: Logistics
//CLASS NAME: IInvPostingCreateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IInvPostingCreateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) InvPostingCreateTTSp(string PStartingCustNum,
		string PEndingCustNum,
		string PStartingInvNum,
		string PEndingInvNum,
		DateTime? PStartingInvDate,
		DateTime? PEndingInvDate,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		string PInvoice,
		string PDebitMemo,
		string PCreditMemo,
		Guid? PSessionID,
		string StartBuilderInvNum = null,
		string EndBuilderInvNum = null,
		string ToSite = null,
		int? CalledFromBackground = 0,
		int? SkipResultSet = 0);
	}
}

