//PROJECT NAME: Data
//CLASS NAME: IValUnit2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IValUnit2
	{
		string ValUnit2Fn(
			string Acct,
			string UnitCode2,
			string Site = null);
	}
}

