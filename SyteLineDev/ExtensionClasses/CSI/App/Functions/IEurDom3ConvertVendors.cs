//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertVendors.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertVendors
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertVendorsSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar);
	}
}

