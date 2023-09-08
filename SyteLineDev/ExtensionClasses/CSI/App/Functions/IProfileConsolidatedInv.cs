//PROJECT NAME: Data
//CLASS NAME: IProfileConsolidatedInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IProfileConsolidatedInv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ProfileConsolidatedInvSp(
			string StartCustNum = null,
			string EndCustNum = null,
			string StartDoNum = null,
			string EndDoNum = null,
			string StartInvNum = null,
			string EndInvNum = null,
			DateTime? StartInvDate = null,
			DateTime? EndInvDate = null,
			decimal? StartShipment = null,
			decimal? EndShipment = null,
			string CalledFrom = "REPRINT",
			Guid? ProcessID = null);
	}
}

