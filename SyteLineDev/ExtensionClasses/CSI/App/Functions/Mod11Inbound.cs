//PROJECT NAME: Data
//CLASS NAME: Mod11Inbound.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Mod11Inbound : IMod11Inbound
	{
		readonly IApplicationDB appDB;
		
		public Mod11Inbound(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public bool? Mod11InboundFn(
			string OCRRef)
		{
			StringType _OCRRef = OCRRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Mod11Inbound](@OCRRef)";
				
				appDB.AddCommandParameter(cmd, "OCRRef", _OCRRef, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<bool?>(cmd);
				
				return Output;
			}
		}
	}
}
