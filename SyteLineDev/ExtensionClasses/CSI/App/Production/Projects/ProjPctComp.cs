//PROJECT NAME: Production
//CLASS NAME: ProjPctComp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjPctComp : IProjPctComp
	{
		readonly IApplicationDB appDB;
		
		public ProjPctComp(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PctComplete) ProjPctCompSp(
			string RefNum,
			string ProjType,
			string ProjNum,
			int? TaskNum,
			decimal? PctComplete)
		{
			ProjNumType _RefNum = RefNum;
			ProjTypeType _ProjType = ProjType;
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjPercentCompleteType _PctComplete = PctComplete;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjPctCompSp";
				
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjType", _ProjType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PctComplete", _PctComplete, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PctComplete = _PctComplete;
				
				return (Severity, PctComplete);
			}
		}
	}
}
