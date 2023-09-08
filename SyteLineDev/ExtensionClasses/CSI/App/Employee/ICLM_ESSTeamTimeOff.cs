//PROJECT NAME: Employee
//CLASS NAME: ICLM_ESSTeamTimeOff.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_ESSTeamTimeOff
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESSTeamTimeOffSp(string EmpNum);
	}
}

