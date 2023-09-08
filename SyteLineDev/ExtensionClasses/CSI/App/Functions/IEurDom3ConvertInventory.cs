//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertInventory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertInventory
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertInventorySp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar);
	}
}

