//PROJECT NAME: Data
//CLASS NAME: SetDateOnly.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetDateOnly : ISetDateOnly
	{
		readonly IApplicationDB appDB;
		
		public SetDateOnly(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SetDateOnlyFn(
			DateTime? InDate)
		{
			DateTimeType _InDate = InDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SetDateOnly](@InDate)";
				
				appDB.AddCommandParameter(cmd, "InDate", _InDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
