//PROJECT NAME: Production
//CLASS NAME: PP_CalcSetupAndRunTimes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_CalcSetupAndRunTimes : IPP_CalcSetupAndRunTimes
	{
		readonly IApplicationDB appDB;
		
		public PP_CalcSetupAndRunTimes(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
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
			string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			SchedHoursType _SetupHrs = SetupHrs;
			SchedHoursType _FinishHrs = FinishHrs;
			QtyUnitNoNegType _PcsPerLbrHr = PcsPerLbrHr;
			RunBasisLbrType _RunBasisLbr = RunBasisLbr;
			QtyUnitNoNegType _PcsPerMchHr = PcsPerMchHr;
			RunBasisLbrType _RunBasisMch = RunBasisMch;
			ListYesNoType _OperTimesFound = OperTimesFound;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_CalcSetupAndRunTimesSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SetupHrs", _SetupHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FinishHrs", _FinishHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PcsPerLbrHr", _PcsPerLbrHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisLbr", _RunBasisLbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PcsPerMchHr", _PcsPerMchHr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RunBasisMch", _RunBasisMch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperTimesFound", _OperTimesFound, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				SetupHrs = _SetupHrs;
				FinishHrs = _FinishHrs;
				PcsPerLbrHr = _PcsPerLbrHr;
				RunBasisLbr = _RunBasisLbr;
				PcsPerMchHr = _PcsPerMchHr;
				RunBasisMch = _RunBasisMch;
				OperTimesFound = _OperTimesFound;
				Infobar = _Infobar;
				
				return (Severity, SetupHrs, FinishHrs, PcsPerLbrHr, RunBasisLbr, PcsPerMchHr, RunBasisMch, OperTimesFound, Infobar);
			}
		}
	}
}
