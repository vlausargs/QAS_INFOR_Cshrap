//PROJECT NAME: Data
//CLASS NAME: IGetFrozenOps.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetFrozenOps
	{
		int? GetFrozenOpsSp(
			int? AltNo);
	}
}

