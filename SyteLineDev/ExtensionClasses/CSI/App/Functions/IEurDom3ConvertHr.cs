//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertHr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertHr
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertHrSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar);
	}
}

