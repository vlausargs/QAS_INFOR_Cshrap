//PROJECT NAME: Material
//CLASS NAME: IGetTaxFreeDays.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetTaxFreeDays
	{
		(int? ReturnCode, int? TaxFreeDays) GetTaxFreeDaysSp(string ProdCode,
		int? TaxFreeDays,
		string PSite = null);
	}
}

