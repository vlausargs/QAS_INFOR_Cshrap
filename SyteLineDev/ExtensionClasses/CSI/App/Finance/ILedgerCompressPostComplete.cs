//PROJECT NAME: Finance
//CLASS NAME: ILedgerCompressPostComplete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ILedgerCompressPostComplete
	{
		(int? ReturnCode, string Infobar) LedgerCompressPostCompleteSp(string PLedgerTable,
		Guid? ProcessId,
		string Infobar,
		int? Override = 0,
		int? IsFromFsb = 0);
	}
}

