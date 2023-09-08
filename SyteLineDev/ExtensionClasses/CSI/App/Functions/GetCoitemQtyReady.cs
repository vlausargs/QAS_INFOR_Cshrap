//PROJECT NAME: Data
//CLASS NAME: GetCoitemQtyReady.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetCoitemQtyReady : IGetCoitemQtyReady
	{
		readonly IApplicationDB appDB;
		
		public GetCoitemQtyReady(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public decimal? GetCoitemQtyReadyFn(
			string CoNum,
			int? CoLine,
			int? CoRelease)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetCoitemQtyReady](@CoNum, @CoLine, @CoRelease)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<decimal?>(cmd);
				
				return Output;
			}
		}
	}
}
