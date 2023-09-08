//PROJECT NAME: Finance
//CLASS NAME: IARActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IARActive
	{
		(int? ReturnCode,
			string Infobar) ARActiveSp(
			string pInvNum,
			string CustNum,
			int? pActive,
			int? pMsg,
			string Site = null,
			int? BatchUpdate = 0,
			string Infobar = null,
			int? CallRaiseError = 1,
			string CustaddrCorpCust = null);
	}
}

