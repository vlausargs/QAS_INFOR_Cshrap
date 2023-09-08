//PROJECT NAME: Data
//CLASS NAME: ICvarSsd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICvarSsd
	{
		(int? ReturnCode,
			string Infobar) CvarSsdSp(
			string VendNum,
			string VendCurrCode,
			Guid? PPoitemRowPointer,
			decimal? PRate,
			int? PVoucher,
			string PTransNat,
			string PTransNat2,
			DateTime? PTransDate,
			decimal? PQty,
			decimal? PNetAdjust,
			decimal? PItemCost,
			string Infobar);
	}
}

