//PROJECT NAME: Data
//CLASS NAME: IHome_PlanningDemandDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHome_PlanningDemandDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_PlanningDemandDetailSp(
			int? DetailDisplay,
			int? UseFullyTransactedOrders = 0,
			DateTime? CutoffDate = null,
			string PlanCode = null,
			string Buyer = null,
			string PMTCodes = "PMT");
	}
}

