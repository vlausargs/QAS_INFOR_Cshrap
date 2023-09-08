//PROJECT NAME: Data
//CLASS NAME: ITrnSsd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITrnSsd
	{
		(int? ReturnCode,
			string Infobar) TrnSsdSp(
			string PType,
			DateTime? PDate,
			decimal? PQty,
			decimal? PTotCost,
			string PFromCurrCode,
			string PToCurrCode,
			string PFromSite,
			string PFromWhse,
			string PToSite,
			string PToWhse,
			string PTrnNum,
			int? PTrnLine,
			string PReasonCode,
			string Infobar);
	}
}

