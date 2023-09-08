//PROJECT NAME: Data
//CLASS NAME: ICheckTwoSitesInSameDb.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckTwoSitesInSameDb
	{
		int? CheckTwoSitesInSameDbFn(
			string Site1,
			string Site2);
	}
}

