//PROJECT NAME: Config
//CLASS NAME: CfgGid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Config
{
	public class CfgGid : ICfgGid
	{
		readonly IApplicationDB appDB;
		
		public CfgGid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string CfgGidFn(
			string RefType,
			string CoNum,
			int? CoLine)
		{
			RefTypeIJOType _RefType = RefType;
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgGid](@RefType, @CoNum, @CoLine)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
