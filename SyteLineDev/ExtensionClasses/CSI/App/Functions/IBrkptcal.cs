//PROJECT NAME: Data
//CLASS NAME: IBrkptcal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IBrkptcal
	{
		(int? ReturnCode,
			decimal? TcCprOnHand) BrkptcalSp(
			int? TLine,
			decimal? PUnitPrice,
			string PCurItem,
			string PCurCurrCode,
			DateTime? PCurEffectDate,
			string PBaseCode,
			string PDolPercent,
			decimal? PBrkQty,
			decimal? PBrkPrice,
			decimal? TcCprOnHand);
	}
}

