//PROJECT NAME: Finance
//CLASS NAME: IPerUnit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPerUnit
	{
		(int? ReturnCode, string Infobar) PerUnitSp(int? StartingSortMethod,
		int? EndingSortMethod,
		string Infobar);
	}
}

