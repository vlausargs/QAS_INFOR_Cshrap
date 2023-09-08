//PROJECT NAME: Data
//CLASS NAME: Prtrxg1SummarizeProjectTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Prtrxg1SummarizeProjectTrans : IPrtrxg1SummarizeProjectTrans
	{
		readonly IApplicationDB appDB;
		
		public Prtrxg1SummarizeProjectTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TRegHrs,
			decimal? TOtHrs,
			decimal? TDtHrs) Prtrxg1SummarizeProjectTransSp(
			string PEmpNum,
			int? PSeq,
			DateTime? PCurStart,
			DateTime? PCurEnd,
			decimal? TRegHrs,
			decimal? TOtHrs,
			decimal? TDtHrs)
		{
			EmpNumType _PEmpNum = PEmpNum;
			PrtrxSeqType _PSeq = PSeq;
			DateType _PCurStart = PCurStart;
			DateType _PCurEnd = PCurEnd;
			TotalHoursType _TRegHrs = TRegHrs;
			TotalHoursType _TOtHrs = TOtHrs;
			TotalHoursType _TDtHrs = TDtHrs;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Prtrxg1SummarizeProjectTransSp";
				
				appDB.AddCommandParameter(cmd, "PEmpNum", _PEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurStart", _PCurStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurEnd", _PCurEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRegHrs", _TRegHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOtHrs", _TOtHrs, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TDtHrs", _TDtHrs, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TRegHrs = _TRegHrs;
				TOtHrs = _TOtHrs;
				TDtHrs = _TDtHrs;
				
				return (Severity, TRegHrs, TOtHrs, TDtHrs);
			}
		}
	}
}
