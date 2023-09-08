//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateDispositionEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateDispositionEsig
	{
		int? RSQC_CreateDispositionEsigSp(Guid? RcvrRowpointer,
		string UserName,
		string ReasonCode,
		Guid? EsigRowpointer,
		string RefType,
		string InspNum,
		decimal? Qty_Accepted,
		string AcceptReason,
		string AcceptDisp,
		decimal? Qty_Rejected,
		string RejectReason,
		string RejectDisp,
		string RejectCause,
		decimal? Qty_Hold,
		string HoldReason);
	}
}

