//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLGetPSJIT.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLGetPSJIT
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLGetPSJITSp(int? TT_Implemented = 0,
		string Wc = null,
		string Facility = null,
		string EmpNum = null,
		int? Page = 1,
		int? IsAcitveTransaction = 0,
		DateTime? PunchDateTime = null,
		string FilterString = null,
		string OrderByString = null,
		string ERPQueryResponseString = null);
	}
}

