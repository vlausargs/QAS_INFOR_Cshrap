//PROJECT NAME: MG.MGCore
//CLASS NAME: IUndefineProcessVariable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.MG.MGCore
{
	public interface IUndefineProcessVariable
	{
		(int? ReturnCode, string Infobar) UndefineProcessVariableSp(string VariableName,
		string Infobar);
	}
}

