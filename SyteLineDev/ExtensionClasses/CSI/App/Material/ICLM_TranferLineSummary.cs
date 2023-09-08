//PROJECT NAME: Material
//CLASS NAME: ICLM_TranferLineSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_TranferLineSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TranferLineSummarySp(string Whse,
		string PMTCodes,
		string FilterString = null,
		string PSiteGroup = null);
	}
}

