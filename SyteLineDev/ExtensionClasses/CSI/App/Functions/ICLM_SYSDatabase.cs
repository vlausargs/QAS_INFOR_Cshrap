//PROJECT NAME: Data
//CLASS NAME: ICLM_SYSDatabase.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_SYSDatabase
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SYSDatabaseSP(
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

