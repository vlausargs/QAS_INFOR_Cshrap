//PROJECT NAME: Data
//CLASS NAME: DecodeMPNFLAGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodeMPNFLAGS : IDecodeMPNFLAGS
	{
		readonly IApplicationDB appDB;
		
		public DecodeMPNFLAGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodeMPNFLAGSFn(
			int? MPNFLAGS)
		{
			IntType _MPNFLAGS = MPNFLAGS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodeMPNFLAGS](@MPNFLAGS)";
				
				appDB.AddCommandParameter(cmd, "MPNFLAGS", _MPNFLAGS, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
