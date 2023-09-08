//PROJECT NAME: Production
//CLASS NAME: IPostDeleteCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPostDeleteCurrOper
	{
		(int? ReturnCode, string Infobar) PostDeleteCurrOperSp(string Job,
		int? Suffix,
		string JobType,
		string Item,
		int? OperNum,
		string Infobar);
	}
}

