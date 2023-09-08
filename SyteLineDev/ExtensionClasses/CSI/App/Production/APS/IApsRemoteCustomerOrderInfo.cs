//PROJECT NAME: Production
//CLASS NAME: IApsRemoteCustomerOrderInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsRemoteCustomerOrderInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ApsRemoteCustomerOrderInfoSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			DateTime? PRequestDate,
			DateTime? PDueDate,
			string PRefType,
			string PRefNum,
			int? PRefLineSuf,
			string PShipSite,
			string PStat,
			string PItem,
			string PWhse);
	}
}

