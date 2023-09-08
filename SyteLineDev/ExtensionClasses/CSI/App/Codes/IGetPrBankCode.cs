//PROJECT NAME: Codes
//CLASS NAME: IGetPrBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IGetPrBankCode
	{
		(int? ReturnCode, string BankCode,
		string Infobar) GetPrBankCodeSp(string BankCode,
		string Infobar);
	}
}

