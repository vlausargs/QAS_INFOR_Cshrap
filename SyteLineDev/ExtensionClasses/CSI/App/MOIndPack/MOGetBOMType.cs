//PROJECT NAME: MOIndPack
//CLASS NAME: MOGetBOMType.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MOGetBOMType : IMOGetBOMType
	{
		readonly IApplicationDB appDB;
		
		public MOGetBOMType(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MOGetBOMTypeFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MOGetBOMType](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
