//PROJECT NAME: Data
//CLASS NAME: DecodeSSFLAGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodeSSFLAGS : IDecodeSSFLAGS
	{
		readonly IApplicationDB appDB;
		
		public DecodeSSFLAGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodeSSFLAGSFn(
			int? SSFLAGS)
		{
			IntType _SSFLAGS = SSFLAGS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodeSSFLAGS](@SSFLAGS)";
				
				appDB.AddCommandParameter(cmd, "SSFLAGS", _SSFLAGS, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
