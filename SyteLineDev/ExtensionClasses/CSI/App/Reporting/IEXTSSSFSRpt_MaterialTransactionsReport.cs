//PROJECT NAME: Reporting
//CLASS NAME: IEXTSSSFSRpt_MaterialTransactionsReport.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IEXTSSSFSRpt_MaterialTransactionsReport
	{
		(int? ReturnCode,
			string ExecStr) EXTSSSFSRpt_MaterialTransactionsReportSp(
			string SroStarting,
			string SroEnding,
			int? SroLineStarting,
			int? SroLineEnding,
			int? SroOperStarting,
			int? SroOperEnding,
			string ExecStr);
	}
}

