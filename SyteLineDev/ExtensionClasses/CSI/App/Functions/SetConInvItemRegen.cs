//PROJECT NAME: Data
//CLASS NAME: SetConInvItemRegen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetConInvItemRegen : ISetConInvItemRegen
	{
		readonly IApplicationDB appDB;
		
		public SetConInvItemRegen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SetConInvItemRegenSp(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetConInvItemRegenSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
