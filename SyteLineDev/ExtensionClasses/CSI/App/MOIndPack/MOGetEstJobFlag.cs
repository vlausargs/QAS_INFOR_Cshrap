//PROJECT NAME: MOIndPack
//CLASS NAME: MOGetEstJobFlag.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MOGetEstJobFlag : IMOGetEstJobFlag
	{
		readonly IApplicationDB appDB;
		
		public MOGetEstJobFlag(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? MOGetEstJobFlagFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MOGetEstJobFlag](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
