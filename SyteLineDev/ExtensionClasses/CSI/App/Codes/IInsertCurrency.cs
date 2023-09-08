//PROJECT NAME: Codes
//CLASS NAME: IInsertCurrency.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IInsertCurrency
	{
		int? InsertCurrencySp(string CurrCode);
	}
}

