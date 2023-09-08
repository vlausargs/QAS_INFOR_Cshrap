//PROJECT NAME: Production
//CLASS NAME: IPreDeleteCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPreDeleteCurrOper
	{
		(int? ReturnCode, string Infobar) PreDeleteCurrOperSp(string Job,
		int? Suffix,
		string JobType,
		int? OperNum,
		string Item,
		string Infobar);
	}
}

