//PROJECT NAME: Production
//CLASS NAME: IValidateEcnValForJobOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IValidateEcnValForJobOper
	{
		(int? ReturnCode, string Infobar) ValidateEcnValForJobOperSp(string Job,
		int? Suffix,
		string JobType,
		string Infobar);
	}
}

