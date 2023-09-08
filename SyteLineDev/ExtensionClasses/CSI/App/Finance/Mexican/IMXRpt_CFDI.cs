//PROJECT NAME: Finance
//CLASS NAME: IMXRpt_CFDI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXRpt_CFDI
	{
		(ICollectionLoadResponse Data, int? ReturnCode,
			string Infobar) MXRpt_CFDISp(
			string pProFormaInvNumStarting = null,
			string pProFormaInvNumEnding = null,
			DateTime? pProFormaInvDateStarting = null,
			DateTime? pProFormaInvDateEnding = null,
			string Infobar = null);
	}
}

