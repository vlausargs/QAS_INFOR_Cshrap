//PROJECT NAME: Data
//CLASS NAME: IVATAcctTransfer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVATAcctTransfer
	{
		(int? ReturnCode,
			string Infobar) VATAcctTransferSp(
			string BankCode,
			Guid? RowPointer,
			string Infobar);
	}
}

