//PROJECT NAME: Logistics
//CLASS NAME: IGetBankCurr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetBankCurr
	{
		(int? ReturnCode, string pBankCurr,
		string Infobar) GetBankCurrSp(string pBankCode,
		string pBankCurr,
		string Infobar);
	}
}

