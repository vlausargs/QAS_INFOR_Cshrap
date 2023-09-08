//PROJECT NAME: Logistics
//CLASS NAME: IValidateBankCodeFormat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IValidateBankCodeFormat
	{
		(int? ReturnCode, string Infobar) ValidateBankCodeFormatSp(string BankCode,
		string EFTFormat,
		string Infobar);
	}
}

