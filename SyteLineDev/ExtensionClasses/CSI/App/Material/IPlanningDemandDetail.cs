//PROJECT NAME: Material
//CLASS NAME: IPlanningDemandDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IPlanningDemandDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) PlanningDemandDetailSp(DateTime? CutOffDate,
		string PlanCode,
		string Buyer,
		string PMTCodes,
		string FilterString = null);

		ICollectionLoadResponse PlanningDemandDetailFn(int? DetailDisplay, int? UseFullyTransactedOrders=0, DateTime? CutoffDate=null, string UserCodeType=null, string UserNameType=null, string PMTCodes="PMT");
	}
}

