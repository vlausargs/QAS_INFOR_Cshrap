//PROJECT NAME: MOIndPack
//CLASS NAME: MOGetBOMProductCycles.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MOIndPack
{
	public class MOGetBOMProductCycles : IMOGetBOMProductCycles
	{
		readonly IApplicationDB appDB;
		
		public MOGetBOMProductCycles(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public long? MOGetBOMProductCyclesFn(
			string CoNum)
		{
			CoNumType _CoNum = CoNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MOGetBOMProductCycles](@CoNum)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<long?>(cmd);
				
				return Output;
			}
		}
	}
}
