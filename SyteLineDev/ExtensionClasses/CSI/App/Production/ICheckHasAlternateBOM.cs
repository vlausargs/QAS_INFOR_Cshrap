//PROJECT NAME: Production
//CLASS NAME: ICheckHasAlternateBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICheckHasAlternateBOM
	{
		int? CheckHasAlternateBOMFn(
			string Item);
	}
}

