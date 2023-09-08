//PROJECT NAME: Data
//CLASS NAME: GetStringByPosition.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetStringByPosition : IGetStringByPosition
	{
		readonly IApplicationDB appDB;
		
		public GetStringByPosition(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetStringByPositionFn(
			string String,
			string Pos)
		{
			InfobarType _String = String;
			StringType _Pos = Pos;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetStringByPosition](@String, @Pos)";
				
				appDB.AddCommandParameter(cmd, "String", _String, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pos", _Pos, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
