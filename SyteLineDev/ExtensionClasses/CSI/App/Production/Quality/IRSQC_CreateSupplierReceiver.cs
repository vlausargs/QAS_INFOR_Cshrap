//PROJECT NAME: Production
//CLASS NAME: IRSQC_CreateSupplierReceiver.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_CreateSupplierReceiver
	{
		(int? ReturnCode, string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar) RSQC_CreateSupplierReceiverSp(decimal? QtyReceived,
		string Whse,
		string PoNum,
		int? PoLine,
		int? PoRelease,
		string Loc,
		DateTime? DueDate,
		string Lot,
		string Item,
		string VendNum,
		DateTime? TransDate,
		int? AutoAccept,
		string CallingFunction,
		string QCLot,
		string UserCode,
		int? firstarticleonly,
		string RcvrNum,
		int? PopUp,
		int? PrintTag,
		string Messages,
		string Infobar);
	}
}

