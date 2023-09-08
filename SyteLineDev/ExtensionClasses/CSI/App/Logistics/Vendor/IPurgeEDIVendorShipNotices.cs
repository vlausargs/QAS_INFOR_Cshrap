//PROJECT NAME: Logistics
//CLASS NAME: IPurgeEDIVendorShipNotices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPurgeEDIVendorShipNotices
	{
		(int? ReturnCode, string Message) PurgeEDIVendorShipNoticesSp(string VendorStarting = null,
		string VendorEnding = null,
		string GRNStarting = null,
		string GRNEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null);
	}
}

