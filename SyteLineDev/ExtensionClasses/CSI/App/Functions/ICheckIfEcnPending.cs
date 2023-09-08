//PROJECT NAME: Data
//CLASS NAME: ICheckIfEcnPending.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckIfEcnPending
	{
		int? CheckIfEcnPendingFn(
			string Job,
			int? Suffix,
			string Item);
	}
}

