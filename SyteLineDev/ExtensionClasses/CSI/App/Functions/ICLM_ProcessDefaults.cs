//PROJECT NAME: Data
//CLASS NAME: ICLM_ProcessDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_ProcessDefaults
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ProcessDefaultsSp(
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

