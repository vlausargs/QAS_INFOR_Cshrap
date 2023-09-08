//PROJECT NAME: Data
//CLASS NAME: ISarbRed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISarbRed
	{
		(int? ReturnCode,
			decimal? TPrice,
			decimal? TcQttTotals,
			int? TBkt) SarbRedSp(
			string SaleSumItem,
			DateTime? TDate,
			decimal? TPrice,
			decimal? TcQttTotals,
			int? TBkt,
			DateTime? SaleSumRefDate,
			int? SaleSumRefBkt);
	}
}

