//PROJECT NAME: Data
//CLASS NAME: IHasRsvdInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IHasRsvdInv
	{
		int? HasRsvdInvFn(
			string Item);
	}
}

