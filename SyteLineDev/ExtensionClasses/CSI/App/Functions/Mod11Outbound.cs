//PROJECT NAME: Data
//CLASS NAME: Mod11Outbound.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Mod11Outbound : IMod11Outbound
	{
		readonly IApplicationDB appDB;
		
		public Mod11Outbound(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string Mod11OutboundFn(
			string OCR)
		{
			StringType _OCR = OCR;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Mod11Outbound](@OCR)";
				
				appDB.AddCommandParameter(cmd, "OCR", _OCR, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
