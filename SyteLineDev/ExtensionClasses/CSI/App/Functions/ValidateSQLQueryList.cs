//PROJECT NAME: Data
//CLASS NAME: ValidateSQLQueryList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ValidateSQLQueryList : IValidateSQLQueryList
	{
		readonly IApplicationDB appDB;
		
		public ValidateSQLQueryList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ValidateSQLQueryListFn(
			string ListString)
		{
			StringType _ListString = ListString;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ValidateSQLQueryList](@ListString)";
				
				appDB.AddCommandParameter(cmd, "ListString", _ListString, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
