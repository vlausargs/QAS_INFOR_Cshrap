//PROJECT NAME: Data
//CLASS NAME: IPadjSSD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPadjSSD
	{
		(int? ReturnCode,
			string Infobar) PadjSSDSp(
			DateTime? PTransDate,
			decimal? PQty,
			decimal? PNetAdjust,
			string PTransNat,
			string PTransNat2,
			decimal? PNewPrice,
			decimal? PCurUCost,
			int? PFixedRate,
			decimal? PExchRate,
			int? PTwoExchRates,
			string PCurrCode,
			string PCustNum,
			string PInvNum,
			int? PInvSeq,
			string PCommCode,
			string PProcessInd,
			string PDelTerm,
			string POrigin,
			string PEcCode,
			string PTransport,
			int? PCurPlaces,
			string Infobar);
	}
}

