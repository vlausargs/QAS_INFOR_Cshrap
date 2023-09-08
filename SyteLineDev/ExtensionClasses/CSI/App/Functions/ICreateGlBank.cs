//PROJECT NAME: Data
//CLASS NAME: ICreateGlBank.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateGlBank
	{
		(int? ReturnCode,
			string Infobar) CreateGlBankSp(
			Guid? ProcessId,
			string BankCode,
			DateTime? CheckDate,
			int? CheckNumber,
			decimal? CheckAmt,
			string Type,
			string RefType,
			string RefNum,
			decimal? DomCheckAmt,
			string Infobar);
	}
}

