//PROJECT NAME: Production
//CLASS NAME: ICheckOperNumForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckOperNumForCurrOper
	{
		(int? ReturnCode, string Infobar) CheckOperNumForCurrOperSp(string Item,
		string Job,
		int? Suffix,
		string JobType,
		int? OperNum,
		string Infobar);
	}
}

