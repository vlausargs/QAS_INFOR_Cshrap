//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsolBuildTemp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsolBuildTemp
	{
		(int? ReturnCode,
			string Infobar) LedgerConsolBuildTempSp(
			string Infobar);
	}
}

