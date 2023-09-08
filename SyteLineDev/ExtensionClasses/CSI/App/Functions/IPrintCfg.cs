//PROJECT NAME: Data
//CLASS NAME: IPrintCfg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrintCfg
	{
		int? PrintCfgSp(
			string PCoNum = null,
			int? PCoLine = 0,
			int? PCoRelease = 0,
			string PPrintConfigurationDetail = "A",
			string PInvNum = null,
			int? PInvLine = 0,
			string RptKey = null);
	}
}

