//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_MaterialTransactionsReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_MaterialTransactionsReport : IEXTSSSFSRpt_MaterialTransactionsReport
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSRpt_MaterialTransactionsReport(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string ExecStr) EXTSSSFSRpt_MaterialTransactionsReportSp(
			string SroStarting,
			string SroEnding,
			int? SroLineStarting,
			int? SroLineEnding,
			int? SroOperStarting,
			int? SroOperEnding,
			string ExecStr)
		{
			CoNumType _SroStarting = SroStarting;
			CoNumType _SroEnding = SroEnding;
			CoPoReleaseArInvSeqType _SroLineStarting = SroLineStarting;
			CoPoReleaseArInvSeqType _SroLineEnding = SroLineEnding;
			CoPoReleaseArInvSeqType _SroOperStarting = SroOperStarting;
			CoPoReleaseArInvSeqType _SroOperEnding = SroOperEnding;
			LongListType _ExecStr = ExecStr;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSRpt_MaterialTransactionsReportSp";
				
				appDB.AddCommandParameter(cmd, "SroStarting", _SroStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroEnding", _SroEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLineStarting", _SroLineStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroLineEnding", _SroLineEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOperStarting", _SroOperStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SroOperEnding", _SroOperEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExecStr", _ExecStr, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ExecStr = _ExecStr;
				
				return (Severity, ExecStr);
			}
		}
	}
}
