//PROJECT NAME: Production
//CLASS NAME: ILocalDisplayForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ILocalDisplayForCurrOper
	{
		(int? ReturnCode, int? WcStat,
		string Infobar) LocalDisplayForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		int? WcStat,
		string Infobar);
	}
}

