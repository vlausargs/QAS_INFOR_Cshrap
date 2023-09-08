//PROJECT NAME: Logistics
//CLASS NAME: IFTSLMESGetEmployeeInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLMESGetEmployeeInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FTSLMESGetEmployeeInfoSp();
	}
}

