//PROJECT NAME: Data
//CLASS NAME: ICLM_EBI_OnTimeShipment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_EBI_OnTimeShipment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_EBI_OnTimeShipmentSp(
			int? Count,
			int? MultipleSites = 0,
			string SiteGroup = null,
			string CustNum = null,
			string CustSeq = null,
			string Item = null);
	}
}

