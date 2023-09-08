//PROJECT NAME: Employee
//CLASS NAME: ICLM_GetLinksInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_GetLinksInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetLinksInfoSp(string FormName,
		string EmpNum);
	}
}

