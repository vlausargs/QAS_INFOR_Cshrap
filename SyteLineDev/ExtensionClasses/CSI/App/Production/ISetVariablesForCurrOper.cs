//PROJECT NAME: Production
//CLASS NAME: ISetVariablesForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ISetVariablesForCurrOper
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) SetVariablesForCurrOperSp(string Item,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

