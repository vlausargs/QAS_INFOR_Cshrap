//PROJECT NAME: Data
//CLASS NAME: App_KeyLength.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class App_KeyLength : IApp_KeyLength
	{
		readonly IApplicationDB appDB;
		
		public App_KeyLength(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? App_KeyLengthFn(
			string DataType)
		{
			StringType _DataType = DataType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[App_KeyLength](@DataType)";
				
				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
