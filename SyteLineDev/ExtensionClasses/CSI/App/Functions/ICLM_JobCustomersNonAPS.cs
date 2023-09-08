//PROJECT NAME: Data
//CLASS NAME: ICLM_JobCustomersNonAPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_JobCustomersNonAPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_JobCustomersNonAPSSp(
			string CustNum = null,
			string FilterString = null,
			string Site = null);
	}
}

