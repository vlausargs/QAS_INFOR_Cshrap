//PROJECT NAME: Finance
//CLASS NAME: IVerifyEndDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IVerifyEndDate
	{
		(int? ReturnCode, string Infobar) VerifyEndDateSp(int? PFiscalYear,
		string Infobar);
	}
}

