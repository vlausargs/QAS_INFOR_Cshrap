//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PRa1rpDoChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PRa1rpDoChecks
	{
		(int? ReturnCode,
			string Infobar) Rpt_PRa1rpDoChecksSp(
			Guid? pPrtrxRowPointer,
			string pTName,
			string pTSsn,
			int? pTDirDep,
			decimal? pTYtd,
			decimal? pTFwt,
			decimal? pTFica,
			decimal? pTSwt,
			decimal? pTOst,
			decimal? pTCwt,
			decimal? pTMed,
			Guid? pSessionID,
			string Infobar);
	}
}

