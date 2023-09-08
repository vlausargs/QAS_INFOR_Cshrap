//PROJECT NAME: Data
//CLASS NAME: ISetCoNumXrefType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetCoNumXrefType
	{
		string SetCoNumXrefTypeFn(
			string InvNum,
			string CoNum,
			int? Rma = 0);
	}
}

