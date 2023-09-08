//PROJECT NAME: Data
//CLASS NAME: IEurDom3ConvertCustomers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEurDom3ConvertCustomers
	{
		(int? ReturnCode,
			string Infobar) EurDom3ConvertCustomersSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			int? TUseStandard,
			string Infobar);
	}
}

