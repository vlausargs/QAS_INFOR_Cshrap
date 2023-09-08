//PROJECT NAME: Data
//CLASS NAME: ITotval.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITotval
	{
		(int? ReturnCode,
			decimal? RetCoPrice,
			decimal? RetShipPrice,
			string Infobar) TotvalSp(
			string LcrNum,
			string CoNum,
			string FromCurrCode,
			string ToCurrCode,
			int? NeedShipPrice,
			decimal? RetCoPrice,
			decimal? RetShipPrice,
			string Infobar);
	}
}

