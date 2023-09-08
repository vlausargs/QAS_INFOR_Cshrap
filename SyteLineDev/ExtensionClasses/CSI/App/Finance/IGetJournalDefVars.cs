//PROJECT NAME: Finance
//CLASS NAME: IGetJournalDefVars.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGetJournalDefVars
	{
		(int? ReturnCode, string DefPrefix,
		string DefSite,
		int? DefFiscalYear,
		int? DefPeriod,
		decimal? DefNumber) GetJournalDefVarsSp(DateTime? PDate = null,
		string PId = null,
		string DefPrefix = null,
		string DefSite = null,
		int? DefFiscalYear = null,
		int? DefPeriod = null,
		decimal? DefNumber = null,
		int? GetNewNumber = 0);
	}
}

