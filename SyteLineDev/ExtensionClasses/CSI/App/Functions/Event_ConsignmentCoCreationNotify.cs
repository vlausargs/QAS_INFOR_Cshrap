//PROJECT NAME: Data
//CLASS NAME: Event_ConsignmentCoCreationNotify.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Event_ConsignmentCoCreationNotify : IEvent_ConsignmentCoCreationNotify
	{
		readonly IApplicationDB appDB;
		
		public Event_ConsignmentCoCreationNotify(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Event_ConsignmentCoCreationNotifySp(
			string CoNum,
			string PortalUsername,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			UsernameType _PortalUsername = PortalUsername;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Event_ConsignmentCoCreationNotifySp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PortalUsername", _PortalUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
