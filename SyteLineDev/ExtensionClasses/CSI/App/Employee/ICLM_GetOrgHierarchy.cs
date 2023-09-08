//PROJECT NAME: Employee
//CLASS NAME: ICLM_GetOrgHierarchy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_GetOrgHierarchy
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetOrgHierarchySp(string EmpNum = null,
		string UserName = null,
		string Infobar = null);
	}
}

