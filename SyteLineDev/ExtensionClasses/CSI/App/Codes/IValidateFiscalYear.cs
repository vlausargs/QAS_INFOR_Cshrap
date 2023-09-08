//PROJECT NAME: Codes
//CLASS NAME: IValidateFiscalYear.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IValidateFiscalYear
	{
		(int? ReturnCode, string Infobar) ValidateFiscalYearSp(int? FiscalYear,
		string Infobar);
	}
}

