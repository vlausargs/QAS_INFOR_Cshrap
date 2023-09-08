//PROJECT NAME: Finance
//CLASS NAME: IPreDeleteCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPreDeleteCheck
	{
		(int? ReturnCode, string Infobar) PreDeleteCheckSp(int? FiscalYear,
		string Infobar);
	}
}

