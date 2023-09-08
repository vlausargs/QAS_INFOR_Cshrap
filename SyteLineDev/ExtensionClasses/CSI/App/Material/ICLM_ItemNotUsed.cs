//PROJECT NAME: Material
//CLASS NAME: ICLM_ItemNotUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_ItemNotUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemNotUsedSp(DateTime? CutoffDate,
		string PMTCodes,
		string FilterString = null,
		string IncludedTypes = null,
		string PSiteGroup = null);
	}
}

