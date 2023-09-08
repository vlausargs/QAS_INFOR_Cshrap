//PROJECT NAME: Reporting
//CLASS NAME: IGlBudgetBuildTemp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IGlBudgetBuildTemp
	{
		(int? ReturnCode,
			string Infobar) GlBudgetBuildTempSp(
			string Infobar);
	}
}

