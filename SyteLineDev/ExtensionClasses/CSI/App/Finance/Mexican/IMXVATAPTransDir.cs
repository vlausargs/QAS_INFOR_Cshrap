//PROJECT NAME: Finance
//CLASS NAME: IMXVATAPTransDir.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXVATAPTransDir
	{
		(int? ReturnCode,
			string Infobar) MXVATAPTransDirSp(
			int? PCheckNum = null,
			string PVendNum = null,
			int? IsReaplication = null,
			DateTime? DistribucionDate = null,
			decimal? OpenPmtExchRate = null,
			string Infobar = null,
			int? AtLeastOneOpenExists = null);
	}
}

