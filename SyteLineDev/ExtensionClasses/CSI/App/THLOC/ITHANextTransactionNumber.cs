//PROJECT NAME: THLOC
//CLASS NAME: ITHANextTransactionNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface ITHANextTransactionNumber
	{
		(int? ReturnCode, string Key,
		string Infobar) THANextTransactionNumberSp(string DocumentType,
		string Prefix,
		DateTime? Date,
		int? KeyLength,
		string Key,
		string Infobar);
	}
}

