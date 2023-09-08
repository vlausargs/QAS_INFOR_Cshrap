//PROJECT NAME: Material
//CLASS NAME: ICLM_TranferLineDetail.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_TranferLineDetail
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TranferLineDetailSp(string Item,
		string Whse,
		string FilterString = null,
		string PSiteGroup = null);
	}
}

