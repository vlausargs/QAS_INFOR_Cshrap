//PROJECT NAME: Data
//CLASS NAME: IsValidDueDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsValidDueDate : IIsValidDueDate
	{
		readonly IApplicationDB appDB;
		
		public IsValidDueDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsValidDueDateFn(
			string RefType,
			DateTime? DueDate)
		{
			RefType _RefType = RefType;
			DateType _DueDate = DueDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsValidDueDate](@RefType, @DueDate)";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DueDate", _DueDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
