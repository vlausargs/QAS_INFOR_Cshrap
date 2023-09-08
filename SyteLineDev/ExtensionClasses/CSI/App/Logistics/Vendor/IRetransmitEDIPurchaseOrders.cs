//PROJECT NAME: Logistics
//CLASS NAME: IRetransmitEDIPurchaseOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRetransmitEDIPurchaseOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIPurchaseOrdersSp(string VendorStarting = null,
		string VendorEnding = null,
		string PoStarting = null,
		string PoEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		int? ProcessFlag = 1,
		string Infobar = null);
	}
}

