//PROJECT NAME: Logistics
//CLASS NAME: IRSQC_CustomerNeedsQC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRSQC_CustomerNeedsQC
	{
		(int? ReturnCode, int? NeedsQC) RSQC_CustomerNeedsQCSp(decimal? ShipmentID,
		int? NeedsQC);
	}
}

