//PROJECT NAME: Data
//CLASS NAME: IPRtrxp1fpPostChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRtrxp1fpPostChecks
	{
		(int? ReturnCode,
			string Infobar) PRtrxp1fpPostChecksSp(
			Guid? pPrtrxRowPointer,
			string pTId,
			string pTRef,
			string pCurrparmsCurrCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar);
	}
}

