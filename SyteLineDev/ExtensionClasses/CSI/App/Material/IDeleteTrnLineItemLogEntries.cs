//PROJECT NAME: Material
//CLASS NAME: IDeleteTrnLineItemLogEntries.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IDeleteTrnLineItemLogEntries
	{
		(int? ReturnCode, string Infobar) DeleteTrnLineItemLogEntriesSp(DateTime? SActivityDate,
		DateTime? EActivityDate,
		string STrnNum,
		string ETrnNum,
		int? STrnLine,
		int? ETrnLine,
		int? CreateInitial,
		string Infobar);
	}
}

