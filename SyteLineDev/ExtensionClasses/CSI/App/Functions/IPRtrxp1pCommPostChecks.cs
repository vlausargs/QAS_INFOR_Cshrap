//PROJECT NAME: Data
//CLASS NAME: IPRtrxp1pCommPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRtrxp1pCommPostChecks
	{
		(int? ReturnCode,
			string Infobar) PRtrxp1pCommPostChecksSp(
			string pPrtrxEmpNum,
			DateTime? pPrtrxCheckDate,
			int? pPrtrxCheckNum,
			string pDeptUnit,
			string Infobar);
	}
}

