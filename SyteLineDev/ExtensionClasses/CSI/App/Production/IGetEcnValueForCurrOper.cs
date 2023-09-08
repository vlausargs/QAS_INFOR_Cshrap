//PROJECT NAME: Production
//CLASS NAME: IGetEcnValueForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetEcnValueForCurrOper
	{
		(int? ReturnCode, string Infobar) GetEcnValueForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

