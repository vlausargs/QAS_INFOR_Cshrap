//PROJECT NAME: Data
//CLASS NAME: ICLM_SQLObjectRevisions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICLM_SQLObjectRevisions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_SQLObjectRevisionsSp(
			string DatabaseName = null,
			string FilterString = null,
			string pSite = null);
	}
}

