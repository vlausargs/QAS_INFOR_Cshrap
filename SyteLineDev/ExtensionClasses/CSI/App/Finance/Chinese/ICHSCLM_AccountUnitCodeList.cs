//PROJECT NAME: Finance
//CLASS NAME: ICHSCLM_AccountUnitCodeList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSCLM_AccountUnitCodeList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSCLM_AccountUnitCodeListSp(string DataType,
		string FilterString = null);
	}
}

