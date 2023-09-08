//PROJECT NAME: Finance
//CLASS NAME: IAp04rRI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IAp04rRI
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string InfoBar) Ap04rRISp(
			Guid? PSessionID,
			int? PDisplayTotals,
			string InfoBar);
	}
}

