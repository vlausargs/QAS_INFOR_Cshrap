//PROJECT NAME: Data
//CLASS NAME: IPrtrxg1SummarizeProjectTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPrtrxg1SummarizeProjectTrans
	{
		(int? ReturnCode,
			decimal? TRegHrs,
			decimal? TOtHrs,
			decimal? TDtHrs) Prtrxg1SummarizeProjectTransSp(
			string PEmpNum,
			int? PSeq,
			DateTime? PCurStart,
			DateTime? PCurEnd,
			decimal? TRegHrs,
			decimal? TOtHrs,
			decimal? TDtHrs);
	}
}

