//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayCheckEarnings.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayCheckEarnings
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_PayCheckEarningsSp(
			DateTime? CheckDate,
			Guid? CheckRowPointer,
			string EmpNum);
	}
}

