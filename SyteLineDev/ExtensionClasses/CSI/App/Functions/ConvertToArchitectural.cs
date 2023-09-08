//PROJECT NAME: Data
//CLASS NAME: ConvertToArchitectural.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvertToArchitectural : IConvertToArchitectural
	{
		readonly IApplicationDB appDB;
		
		public ConvertToArchitectural(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvertToArchitecturalFn(
			string Value)
		{
			StringType _Value = Value;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvertToArchitectural](@Value)";
				
				appDB.AddCommandParameter(cmd, "Value", _Value, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
