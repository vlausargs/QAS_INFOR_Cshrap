//PROJECT NAME: Logistics
//CLASS NAME: ICLM_VchPrTaxDistCurCnv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_VchPrTaxDistCurCnv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_VchPrTaxDistCurCnvSp(int? PPreRegister,
		string PCurrCode,
		DateTime? PDate,
		decimal? PExchRate);
	}
}

