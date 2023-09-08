//PROJECT NAME: Codes
//CLASS NAME: ICLM_PerTotByProdcode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_PerTotByProdcode
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PerTotByProdcodeSp(string FilterString = null,
		string SiteGroup = null);
	}
}

