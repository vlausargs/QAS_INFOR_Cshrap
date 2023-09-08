//PROJECT NAME: Codes
//CLASS NAME: ICLM_DimCatTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_DimCatTable
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimCatTableSp(
			Guid? TableRowPointer,
			string object_name,
			string dimension);
	}
}

