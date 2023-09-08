//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetListSource.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetListSource
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetListSourceSp(string Acct = null,
		string Attribute = null,
		string SiteRef = null);
	}
}

