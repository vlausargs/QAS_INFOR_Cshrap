//PROJECT NAME: Data
//CLASS NAME: ICmpltPi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICmpltPi
	{
		(int? ReturnCode,
			string Infobar) CmpltPiSp(
			string CallFrom,
			string PVendNum,
			string PVendCurrency,
			int? PPlaces,
			Guid? PoitemRowPointer,
			int? PerformUpdate,
			string PPoType,
			DateTime? POrderDate,
			string PType,
			decimal? PExchRate,
			string POldStat,
			string Infobar);
	}
}

