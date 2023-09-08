//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateRMAReceiver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateRMAReceiver
	{
		(int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string TagStatus,
		string Messages,
		string Infobar) RSQC_CreateRMAReceiverSp(decimal? QtyReceived,
		string Whse,
		string RMANum,
		int? RMALine,
		string Loc,
		string Lot,
		string Item,
		string CustNum,
		DateTime? TransDate,
		int? AutoQCHold,
		string CallingFunction,
		string QCLot,
		string UserCode,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string TagStatus,
		string Messages,
		string Infobar);
	}
}

