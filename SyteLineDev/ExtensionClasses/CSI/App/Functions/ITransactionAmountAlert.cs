//PROJECT NAME: Data
//CLASS NAME: ITransactionAmountAlert.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransactionAmountAlert
	{
		(int? ReturnCode,
			string Infobar) TransactionAmountAlertSp(
			string Infobar);
	}
}

