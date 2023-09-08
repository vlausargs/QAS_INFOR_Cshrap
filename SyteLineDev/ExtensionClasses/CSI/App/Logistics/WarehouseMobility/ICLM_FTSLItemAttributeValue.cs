//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLItemAttributeValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLItemAttributeValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLItemAttributeValueSp(Guid? RowPointer,
		string AttrGroup);
	}
}

