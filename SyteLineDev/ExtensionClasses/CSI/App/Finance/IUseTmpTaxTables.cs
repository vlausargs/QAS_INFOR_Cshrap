//PROJECT NAME: Finance
//CLASS NAME: IUseTmpTaxTables.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IUseTmpTaxTables
	{
		(int? ReturnCode,
			int? LocalInit,
			string Infobar) UseTmpTaxTablesSp(
			Guid? PSessionId,
			int? LocalInit,
			string Infobar);
	}
}

