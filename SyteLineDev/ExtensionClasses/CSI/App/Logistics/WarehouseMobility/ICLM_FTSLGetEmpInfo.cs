//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetEmpInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetEmpInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetEmpInfoSp(string EmpNum,
		int? TAImplement = 0);
	}
}

