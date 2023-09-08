//PROJECT NAME: Finance
//CLASS NAME: ICheckDraftNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Drafts
{
	public interface ICheckDraftNum
	{
		int? CheckDraftNumSp(
			string CustNum,
			string InvNum,
			string Infobar);
	}
}

