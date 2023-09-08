//PROJECT NAME: Data
//CLASS NAME: GetSsl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetSsl : IGetSsl
	{
		readonly IApplicationDB appDB;
		
		public GetSsl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetSslFn(
			string CoNum,
			string CoType)
		{
			CoNumType _CoNum = CoNum;
			CoTypeType _CoType = CoType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetSsl](@CoNum, @CoType)";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
