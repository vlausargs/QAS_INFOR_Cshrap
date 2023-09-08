//PROJECT NAME: Data
//CLASS NAME: ICLM_Intranets.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_Intranets
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_IntranetsSp(
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

