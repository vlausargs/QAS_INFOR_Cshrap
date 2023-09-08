//PROJECT NAME: Adapters
//CLASS NAME: ICalcCurrRateExpireDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Adapters
{
	public interface ICalcCurrRateExpireDate
	{
		(int? ReturnCode, DateTime? pExpireDate,
		string Infobar) CalcCurrRateExpireDateSp(string pDomCurrCode,
		string pForCurrCode,
		string pEffectiveDate,
		DateTime? pExpireDate,
		string Infobar);
	}
}

