//PROJECT NAME: Finance
//CLASS NAME: IMXDIOTFileGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Mexican
{
	public interface IMXDIOTFileGen
	{
		(int? ReturnCode, string outFileName,
		string outFileContent) MXDIOTFileGenSp(string outFileName = null,
		string outFileContent = null,
		DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		int? Reprint = 0,
		int? Close = 0,
		string PrintOrCommit = "C");
	}
}

