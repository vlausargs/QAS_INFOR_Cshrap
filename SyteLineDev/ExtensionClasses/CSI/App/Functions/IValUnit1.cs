//PROJECT NAME: Data
//CLASS NAME: IValUnit1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValUnit1
	{
		string ValUnit1Fn(
			string Acct,
			string UnitCode1,
			string Site = null);
	}
}

