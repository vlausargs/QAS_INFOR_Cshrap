//PROJECT NAME: Data
//CLASS NAME: ICLM_TableIndexes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_TableIndexes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TableIndexesSp(
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

