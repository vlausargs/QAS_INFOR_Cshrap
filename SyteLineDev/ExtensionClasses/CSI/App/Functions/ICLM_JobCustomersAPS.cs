//PROJECT NAME: Data
//CLASS NAME: ICLM_JobCustomersAPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_JobCustomersAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_JobCustomersAPSSp(
			string CustNum = null,
			string FilterString = null,
			string Site = null);
	}
}

