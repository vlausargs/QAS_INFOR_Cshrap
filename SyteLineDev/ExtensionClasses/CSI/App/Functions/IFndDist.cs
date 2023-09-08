//PROJECT NAME: Data
//CLASS NAME: IFndDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFndDist
	{
		Guid? FndDistFn(
			string Item,
			string Whse);
	}
}

