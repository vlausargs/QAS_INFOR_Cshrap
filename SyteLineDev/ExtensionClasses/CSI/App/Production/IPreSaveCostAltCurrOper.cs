//PROJECT NAME: Production
//CLASS NAME: IPreSaveCostAltCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPreSaveCostAltCurrOper
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) PreSaveCostAltCurrOperSp(string CostingAlt,
		string Item,
		int? OperNum,
		string Wc,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

