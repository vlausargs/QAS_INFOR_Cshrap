//PROJECT NAME: Logistics
//CLASS NAME: IAPVchPostPopulateTT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAPVchPostPopulateTT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) APVchPostPopulateTTSP(Guid? PSessionID,
		string PStartingVendNum,
		string PEndingVendNum,
		int? PStartingVoucherNum,
		int? PEndingVoucherNum,
		DateTime? PStartingDueDate,
		DateTime? PEndingDueDate,
		DateTime? PStartingDistDate,
		DateTime? PEndingDistDate,
		string PAuthStatus,
		string PSortVchVend,
		int? CalledFromBackground = 0);
	}
}

