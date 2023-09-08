//PROJECT NAME: Logistics
//CLASS NAME: IPurgeEDIShipSchedules.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPurgeEDIShipSchedules
	{
		(int? ReturnCode, string Message) PurgeEDIShipSchedulesSp(string VendorStarting = null,
		string VendorEnding = null,
		string PoStarting = null,
		string PoEnding = null,
		DateTime? OrderDateStarting = null,
		DateTime? OrderDateEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		string ExOptprPostedEmp = null,
		int? OrderDateStartingOffset = null,
		int? OrderDateEndingOffset = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		string Message = null);
	}
}

