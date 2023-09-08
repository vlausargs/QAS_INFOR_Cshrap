//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCustItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCustItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCustItemsSp(string CustNum = null,
		string Item = null,
		string CustItem = null,
		string CoNum = null,
		int? CoLine = null,
		int? CoRelease = null,
		string Infobar = null);
	}
}

