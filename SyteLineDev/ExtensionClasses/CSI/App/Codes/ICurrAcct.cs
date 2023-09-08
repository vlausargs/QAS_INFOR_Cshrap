//PROJECT NAME: Codes
//CLASS NAME: ICurrAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICurrAcct
	{
		(int? ReturnCode, int? IsRecordCreated,
		DateTime? NewRecordDate,
		Guid? NewRowPointer) CurrAcctSp(string CurrCode,
		int? IsRecordCreated,
		DateTime? NewRecordDate,
		Guid? NewRowPointer);
	}
}

