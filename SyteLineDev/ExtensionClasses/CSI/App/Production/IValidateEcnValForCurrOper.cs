//PROJECT NAME: Production
//CLASS NAME: IValidateEcnValForCurrOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateEcnValForCurrOper
	{
		(int? ReturnCode, string Job,
		int? Suffix,
		string JobType,
		string Infobar) ValidateEcnValForCurrOperSp(string Item,
		int? OperNum,
		string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

