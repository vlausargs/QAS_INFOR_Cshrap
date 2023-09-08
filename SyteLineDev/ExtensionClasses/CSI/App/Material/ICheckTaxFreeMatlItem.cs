//PROJECT NAME: Material
//CLASS NAME: ICheckTaxFreeMatlItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICheckTaxFreeMatlItem
	{
		(int? ReturnCode, int? DisableEnable) CheckTaxFreeMatlItemSp(string Item = null,
		string CallFrom = null,
		int? DisableEnable = null,
		string PSite = null);

		int? CheckTaxFreeMatlItemFn(
			string Item = null,
			string CallFrom = null,
			string PSite = null);
	}
}

