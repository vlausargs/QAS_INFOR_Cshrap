//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutivePOValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutivePOValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutivePOValueSp(string SiteGroup,
		DateTime? DateStarting,
		DateTime? DateEnding,
		string FilterString = null);
	}
}

