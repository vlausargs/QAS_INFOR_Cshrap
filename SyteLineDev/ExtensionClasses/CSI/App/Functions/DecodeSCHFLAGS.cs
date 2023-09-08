//PROJECT NAME: Data
//CLASS NAME: DecodeSCHFLAGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodeSCHFLAGS : IDecodeSCHFLAGS
	{
		readonly IApplicationDB appDB;
		
		public DecodeSCHFLAGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodeSCHFLAGSFn(
			int? SCHFLAGS)
		{
			IntType _SCHFLAGS = SCHFLAGS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodeSCHFLAGS](@SCHFLAGS)";
				
				appDB.AddCommandParameter(cmd, "SCHFLAGS", _SCHFLAGS, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
