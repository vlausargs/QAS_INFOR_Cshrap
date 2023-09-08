//PROJECT NAME: Production
//CLASS NAME: VerifyFromPr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class VerifyFromPr : IVerifyFromPr
	{
		readonly IApplicationDB appDB;
		
		
		public VerifyFromPr(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? StartTask,
		int? EndTask,
		int? NoTask,
		string Infobar) VerifyFromProj(string FromType,
		string FromProj,
		int? StartTask,
		int? EndTask,
		int? NoTask,
		string Infobar)
		{
			ProjTypeType _FromType = FromType;
			ProjNumType _FromProj = FromProj;
			TaskNumType _StartTask = StartTask;
			TaskNumType _EndTask = EndTask;
			ListYesNoType _NoTask = NoTask;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "VerifyFromProj";
				
				appDB.AddCommandParameter(cmd, "FromType", _FromType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProj", _FromProj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartTask", _StartTask, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndTask", _EndTask, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NoTask", _NoTask, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StartTask = _StartTask;
				EndTask = _EndTask;
				NoTask = _NoTask;
				Infobar = _Infobar;
				
				return (Severity, StartTask, EndTask, NoTask, Infobar);
			}
		}
	}
}
