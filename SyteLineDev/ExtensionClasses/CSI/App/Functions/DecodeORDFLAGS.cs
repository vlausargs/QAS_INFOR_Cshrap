//PROJECT NAME: Data
//CLASS NAME: DecodeORDFLAGS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DecodeORDFLAGS : IDecodeORDFLAGS
	{
		readonly IApplicationDB appDB;
		
		public DecodeORDFLAGS(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DecodeORDFLAGSFn(
			int? ORDFLAGS)
		{
			IntType _ORDFLAGS = ORDFLAGS;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DecodeORDFLAGS](@ORDFLAGS)";
				
				appDB.AddCommandParameter(cmd, "ORDFLAGS", _ORDFLAGS, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
