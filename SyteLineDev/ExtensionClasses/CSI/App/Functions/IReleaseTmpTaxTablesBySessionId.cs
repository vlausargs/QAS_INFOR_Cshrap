//PROJECT NAME: Data
//CLASS NAME: IReleaseTmpTaxTablesBySessionId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReleaseTmpTaxTablesBySessionId
	{
		(int? ReturnCode,
			int? LocalInit) ReleaseTmpTaxTablesBySessionIdSp(
			Guid? PSessionId,
			int? LocalInit = 1);
	}
}

