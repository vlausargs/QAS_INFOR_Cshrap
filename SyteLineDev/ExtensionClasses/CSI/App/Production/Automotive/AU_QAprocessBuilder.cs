//PROJECT NAME: Production
//CLASS NAME: AU_QAprocessBuilder.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Automotive
{
	public interface IAU_QAprocessBuilder
	{
		int? AU_QAprocessBuilderSp(byte? IncludeQAProcesses,
		byte? IncludeQAProcessDefn,
		string QAprocessIDStarting = null,
		string QAprocessIDEnding = null,
		string QAProcessStarting = null,
		string QAProcessEnding = null,
		string ProcessSourceTypeStart = null,
		string ProcessSourceTypeEnd = null,
		string ProcessSourceStarting = null,
		string ProcessSourceEnding = null,
		decimal? UserId = null);
	}
	
	public class AU_QAprocessBuilder : IAU_QAprocessBuilder
	{
		readonly IApplicationDB appDB;
		
		public AU_QAprocessBuilder(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AU_QAprocessBuilderSp(byte? IncludeQAProcesses,
		byte? IncludeQAProcessDefn,
		string QAprocessIDStarting = null,
		string QAprocessIDEnding = null,
		string QAProcessStarting = null,
		string QAProcessEnding = null,
		string ProcessSourceTypeStart = null,
		string ProcessSourceTypeEnd = null,
		string ProcessSourceStarting = null,
		string ProcessSourceEnding = null,
		decimal? UserId = null)
		{
			FlagNyType _IncludeQAProcesses = IncludeQAProcesses;
			FlagNyType _IncludeQAProcessDefn = IncludeQAProcessDefn;
			AU_QAProcessIDType _QAprocessIDStarting = QAprocessIDStarting;
			AU_QAProcessIDType _QAprocessIDEnding = QAprocessIDEnding;
			AU_QAProcessType _QAProcessStarting = QAProcessStarting;
			AU_QAProcessType _QAProcessEnding = QAProcessEnding;
			RefTypeIJKOPRSTWType _ProcessSourceTypeStart = ProcessSourceTypeStart;
			RefTypeIJKOPRSTWType _ProcessSourceTypeEnd = ProcessSourceTypeEnd;
			ReferenceType _ProcessSourceStarting = ProcessSourceStarting;
			ReferenceType _ProcessSourceEnding = ProcessSourceEnding;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_QAprocessBuilderSp";
				
				appDB.AddCommandParameter(cmd, "IncludeQAProcesses", _IncludeQAProcesses, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeQAProcessDefn", _IncludeQAProcessDefn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAprocessIDStarting", _QAprocessIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAprocessIDEnding", _QAprocessIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAProcessStarting", _QAProcessStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QAProcessEnding", _QAProcessEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceTypeStart", _ProcessSourceTypeStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceTypeEnd", _ProcessSourceTypeEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceStarting", _ProcessSourceStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessSourceEnding", _ProcessSourceEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
