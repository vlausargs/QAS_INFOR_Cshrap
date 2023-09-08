//PROJECT NAME: Codes
//CLASS NAME: ICLM_DimTable2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_DimTable2
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimTable2Sp(
			Guid? TableRowPointer,
			string ObjectName,
			string Dimension);
	}
}

