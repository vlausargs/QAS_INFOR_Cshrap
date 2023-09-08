//PROJECT NAME: Production
//CLASS NAME: ICLM_JobCustomers.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_JobCustomers
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_JobCustomersSp(string CustNum = null,
		string FilterString = null,
		string SiteGroup = null);
	}
}

