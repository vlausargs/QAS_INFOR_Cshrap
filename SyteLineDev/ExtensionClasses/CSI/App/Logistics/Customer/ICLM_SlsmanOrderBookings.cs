//PROJECT NAME: Logistics
//CLASS NAME: ICLM_SlsmanOrderBookings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_SlsmanOrderBookings
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SlsmanOrderBookingsSP(string SlsManList,
		DateTime? StartDate,
		int? RMAInclude,
		string FilterString);
	}
}

