//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ConsolInvPrintCfg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ConsolInvPrintCfg
	{
		int? Rpt_ConsolInvPrintCfgSp(
			string PCoNum = null,
			int? PCoLine = 0,
			int? PCoRelease = 0,
			string PPrintConfigurationDetail = "A",
			string PInvNum = null,
			int? PInvLine = 0);
	}
}

