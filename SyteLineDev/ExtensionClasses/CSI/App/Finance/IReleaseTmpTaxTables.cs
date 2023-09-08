//PROJECT NAME: Finance
//CLASS NAME: IReleaseTmpTaxTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IReleaseTmpTaxTables
	{
		(int? ReturnCode,
			int? LocalInit) ReleaseTmpTaxTablesSp(
			Guid? PSessionId,
			int? LocalInit = 1);
	}
}

