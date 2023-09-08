//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateMrrDispositionEsig.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateMrrDispositionEsig
	{
		int? RSQC_CreateMrrDispositionEsigSp(Guid? RcvrRowpointer,
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
		string RejectCause);
	}
}

