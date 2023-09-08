//PROJECT NAME: Employee
//CLASS NAME: ICLM_PayCheckTaxesAndDeductions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface ICLM_PayCheckTaxesAndDeductions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_PayCheckTaxesAndDeductionsSp(DateTime? CheckDate,
		Guid? CheckRowPointer,
		string EmpNum);
	}
}

