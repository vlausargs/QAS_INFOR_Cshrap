//PROJECT NAME: Production
//CLASS NAME: ICheckHasAlternateBOMAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckHasAlternateBOMAll
	{
		int? CheckHasAlternateBOMAllFn(
			string Item,
			string Site);
	}
}

