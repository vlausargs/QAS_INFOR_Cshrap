//PROJECT NAME: Employee
//CLASS NAME: ICLM_ESSGetEmpInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ESSGetEmpInfo
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_ESSGetEmpInfoSp(string EmpNum = null,
		string UserName = null,
		string Infobar = null);
	}
}

