//PROJECT NAME: Finance
//CLASS NAME: IMXVATARMultiSiteTransDir.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXVATARMultiSiteTransDir
	{
		(int? ReturnCode,
			string Infobar) MXVATARMultiSiteTransDirSp(
			int? PCheckNum = null,
			string PInvNum = null,
			string PCustNum = null,
			string RefType = null,
			string Type = null,
			string RefNum = null,
			int? BankRecon = null,
			DateTime? UfReconDate = null,
			DateTime? CheckDate = null,
			int? CheckNum = null,
			decimal? CheckAmt = null,
			string BankCode = null,
			int? CustCheckNum = null,
			string BankCurrCode = null,
			int? IsReaplication = null,
			DateTime? DistribucionDate = null,
			decimal? OpenPmtExchRate = null,
			string Infobar = null);
	}
}

