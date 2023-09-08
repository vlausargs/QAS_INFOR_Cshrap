//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsMergeToList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsMergeToList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsMergeToListSp(int? AltNum,
		Guid? Rowpointer);
	}
}

