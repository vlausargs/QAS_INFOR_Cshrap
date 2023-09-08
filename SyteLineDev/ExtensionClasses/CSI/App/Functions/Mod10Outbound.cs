//PROJECT NAME: Data
//CLASS NAME: Mod10Outbound.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Mod10Outbound : IMod10Outbound
	{
		readonly IApplicationDB appDB;
		
		public Mod10Outbound(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string Mod10OutboundFn(
			string OCR)
		{
			StringType _OCR = OCR;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Mod10Outbound](@OCR)";
				
				appDB.AddCommandParameter(cmd, "OCR", _OCR, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
