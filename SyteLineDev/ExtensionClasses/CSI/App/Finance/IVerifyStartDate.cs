//PROJECT NAME: Finance
//CLASS NAME: IVerifyStartDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVerifyStartDate
	{
		(int? ReturnCode, string Infobar) VerifyStartDateSp(DateTime? PStartDate,
		int? PFiscalYear,
		string Infobar);
	}
}

