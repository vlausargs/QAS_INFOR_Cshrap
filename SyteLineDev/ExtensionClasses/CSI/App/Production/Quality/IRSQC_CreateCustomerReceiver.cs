//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateCustomerReceiver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateCustomerReceiver
	{
		(int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar) RSQC_CreateCustomerReceiverSp(decimal? QtyReceived,
		string Whse,
		string CoNum,
		int? CoLine,
		int? CoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string CustNum,
		DateTime? HoldDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
		int? firstarticleonly,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar);
	}
}

