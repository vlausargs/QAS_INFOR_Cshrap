//PROJECT NAME: Logistics
//CLASS NAME: IHome_GetPastDueValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IHome_GetPastDueValues
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_GetPastDueValuesSp(DateTime? PastDueDate = null,
		string Buyer = null,
		string PSiteGroup = null,
		string FilterString = null);
	}
}

