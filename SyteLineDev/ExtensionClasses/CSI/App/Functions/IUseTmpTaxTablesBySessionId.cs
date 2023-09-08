//PROJECT NAME: Data
//CLASS NAME: IUseTmpTaxTablesBySessionId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUseTmpTaxTablesBySessionId
	{
		(int? ReturnCode,
			int? LocalInit,
			string Infobar) UseTmpTaxTablesBySessionIdSp(
			Guid? PSessionId,
			int? LocalInit,
			string Infobar);
	}
}

