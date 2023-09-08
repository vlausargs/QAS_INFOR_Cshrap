//PROJECT NAME: Finance
//CLASS NAME: MXDIOTFileGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Mexican
{
	public class MXDIOTFileGen : IMXDIOTFileGen
	{
		readonly IApplicationDB appDB;
		
		
		public MXDIOTFileGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string outFileName,
		string outFileContent) MXDIOTFileGenSp(string outFileName = null,
		string outFileContent = null,
		DateTime? ReconDateStarting = null,
		DateTime? ReconDateEnding = null,
		int? EndPeriod = null,
		int? FiscalYear = null,
		int? Reprint = 0,
		int? Close = 0,
		string PrintOrCommit = "C")
		{
			StringType _outFileName = outFileName;
			StringType _outFileContent = outFileContent;
			DateType _ReconDateStarting = ReconDateStarting;
			DateType _ReconDateEnding = ReconDateEnding;
			FinPeriodType _EndPeriod = EndPeriod;
			FiscalYearType _FiscalYear = FiscalYear;
			ByteType _Reprint = Reprint;
			ByteType _Close = Close;
			StringType _PrintOrCommit = PrintOrCommit;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MXDIOTFileGenSp";
				
				appDB.AddCommandParameter(cmd, "outFileName", _outFileName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "outFileContent", _outFileContent, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReconDateStarting", _ReconDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReconDateEnding", _ReconDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPeriod", _EndPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FiscalYear", _FiscalYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reprint", _Reprint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Close", _Close, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintOrCommit", _PrintOrCommit, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				outFileName = _outFileName;
				outFileContent = _outFileContent;
				
				return (Severity, outFileName, outFileContent);
			}
		}
	}
}
