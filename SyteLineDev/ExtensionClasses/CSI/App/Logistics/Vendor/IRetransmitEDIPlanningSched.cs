//PROJECT NAME: Logistics
//CLASS NAME: IRetransmitEDIPlanningSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IRetransmitEDIPlanningSched
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) RetransmitEDIPlanningSchedSp(string VendorStarting = null,
		string VendorEnding = null,
		int? SchedNumStarting = null,
		int? SchedNumEnding = null,
		DateTime? CDateStarting = null,
		DateTime? CDateEnding = null,
		int? CDateStartingOffset = null,
		int? CDateEndingOffset = null,
		int? ProcessFlag = 1,
		string Infobar = null);
	}
}

