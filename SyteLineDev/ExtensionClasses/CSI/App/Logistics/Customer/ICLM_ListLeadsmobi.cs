//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ListLeadsmobi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_ListLeadsmobi
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ListLeadsmobiSp(
			string SlsmanFilter = null);
	}
}

