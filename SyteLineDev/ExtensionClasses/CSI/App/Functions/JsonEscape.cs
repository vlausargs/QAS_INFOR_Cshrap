//PROJECT NAME: Data
//CLASS NAME: JsonEscape.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class JsonEscape : IJsonEscape
	{
		readonly IApplicationDB appDB;
		
		public JsonEscape(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string JsonEscapeFn(
			string value)
		{
			StringType _value = value;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[JsonEscape](@value)";
				
				appDB.AddCommandParameter(cmd, "value", _value, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
