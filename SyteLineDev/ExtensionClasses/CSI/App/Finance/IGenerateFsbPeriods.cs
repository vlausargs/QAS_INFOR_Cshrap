//PROJECT NAME: Finance
//CLASS NAME: IGenerateFsbPeriods.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGenerateFsbPeriods
	{
		int? GenerateFsbPeriodsSp(int? FiscalYear,
		string PeriodName,
		int? StepMonths);
	}
}

