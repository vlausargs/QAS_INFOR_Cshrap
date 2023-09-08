//PROJECT NAME: Material
//CLASS NAME: MrpNet.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpNet : IMrpNet
	{
		readonly IApplicationDB appDB;
		
		
		public MrpNet(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MrpNetSp(string UserMrpPlanningType = "R",
		string FormCaption = null,
		int? BgTaskID = null,
		string Infobar = null,
		int? DebugLevel = 0,
		int? ItemElapsedTime = 0)
		{
			ListRegenerationNetChangeType _UserMrpPlanningType = UserMrpPlanningType;
			LongListType _FormCaption = FormCaption;
			GenericNoType _BgTaskID = BgTaskID;
			InfobarType _Infobar = Infobar;
			IntType _DebugLevel = DebugLevel;
			IntType _ItemElapsedTime = ItemElapsedTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpNetSp";
				
				appDB.AddCommandParameter(cmd, "UserMrpPlanningType", _UserMrpPlanningType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FormCaption", _FormCaption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BgTaskID", _BgTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DebugLevel", _DebugLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemElapsedTime", _ItemElapsedTime, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
