//PROJECT NAME: Production
//CLASS NAME: IPP_CalcSetupAndRunTimes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_CalcSetupAndRunTimes
	{
		(int? ReturnCode,
			decimal? SetupHrs,
			decimal? FinishHrs,
			decimal? PcsPerLbrHr,
			string RunBasisLbr,
			decimal? PcsPerMchHr,
			string RunBasisMch,
			int? OperTimesFound,
			string Infobar) PP_CalcSetupAndRunTimesSp(
			string Job,
			int? Suffix,
			int? OperNum,
			decimal? SetupHrs,
			decimal? FinishHrs,
			decimal? PcsPerLbrHr,
			string RunBasisLbr,
			decimal? PcsPerMchHr,
			string RunBasisMch,
			int? OperTimesFound,
			string Infobar);
	}
}

