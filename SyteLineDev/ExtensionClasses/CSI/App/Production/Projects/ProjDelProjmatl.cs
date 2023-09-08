//PROJECT NAME: Production
//CLASS NAME: ProjDelProjmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Projects
{
	public class ProjDelProjmatl : IProjDelProjmatl
	{
		readonly IApplicationDB appDB;
		
		public ProjDelProjmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ProjDelProjmatlSp(
			string ProjNum,
			int? TaskNum,
			int? SeqNum,
			string Infobar)
		{
			ProjNumType _ProjNum = ProjNum;
			TaskNumType _TaskNum = TaskNum;
			ProjmatlSeqType _SeqNum = SeqNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjDelProjmatlSp";
				
				appDB.AddCommandParameter(cmd, "ProjNum", _ProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNum", _TaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SeqNum", _SeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
