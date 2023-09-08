//PROJECT NAME: CSIProjects
//CLASS NAME: NextProjTask.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface INextProjTask
	{
		int NextProjTaskSp(string ProjNum,
		                   ref int? ProjTaskNum,
		                   ref string Infobar);
	}
	
	public class NextProjTask : INextProjTask
	{
		readonly IApplicationDB appDB;
		
		public NextProjTask(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int NextProjTaskSp(string ProjNum,
		                          ref int? ProjTaskNum,
		                          ref string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _ProjTaskNum = ProjTaskNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextProjTaskSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjTaskNum", _ProjTaskNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ProjTaskNum = _ProjTaskNum;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
