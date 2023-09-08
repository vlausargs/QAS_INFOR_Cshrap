//PROJECT NAME: Material
//CLASS NAME: ICLM_MRPOrderAction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_MRPOrderAction
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_MRPOrderActionSp(string Item = null,
		DateTime? EndDate = null,
		string Source = null,
		string FilterString = null);
	}
}

