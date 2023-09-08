//PROJECT NAME: Codes
//CLASS NAME: ICLM_DimensionBinding.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_DimensionBinding
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimensionBindingSp(string DimType,
		string ObjectName,
		string TableName,
		string FilterString);
	}
}

