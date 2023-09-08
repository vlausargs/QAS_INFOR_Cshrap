//PROJECT NAME: Employee
//CLASS NAME: IPredisplayEmploymentEligibility.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IPredisplayEmploymentEligibility
	{
		(int? ReturnCode,
		int? PCheckSsnEnabled) PredisplayEmploymentEligibilitySp(
			int? PCheckSsnEnabled);
	}
}

