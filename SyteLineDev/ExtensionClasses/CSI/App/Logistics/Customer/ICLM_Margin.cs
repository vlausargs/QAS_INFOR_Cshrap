//PROJECT NAME: Logistics
//CLASS NAME: ICLM_Margin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_Margin
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_MarginSp(string CustNum = null,
		string FilterString = null,
		string PSiteGroup = null);
	}
}

