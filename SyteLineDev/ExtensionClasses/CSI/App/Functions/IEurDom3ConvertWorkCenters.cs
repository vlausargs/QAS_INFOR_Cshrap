//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertWorkCenters.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertWorkCenters
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertWorkCentersSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar);
	}
}

