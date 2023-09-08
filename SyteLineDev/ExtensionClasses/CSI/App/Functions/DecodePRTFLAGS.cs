//PROJECT NAME: Data
//CLASS NAME: DecodePRTFLAGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodePRTFLAGS : IDecodePRTFLAGS
	{
		readonly IApplicationDB appDB;
		
		public DecodePRTFLAGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodePRTFLAGSFn(
			int? PRTFLAGS)
		{
			IntType _PRTFLAGS = PRTFLAGS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodePRTFLAGS](@PRTFLAGS)";
				
				appDB.AddCommandParameter(cmd, "PRTFLAGS", _PRTFLAGS, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
