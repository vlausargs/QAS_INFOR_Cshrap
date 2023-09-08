//PROJECT NAME: Data
//CLASS NAME: InternationalDateToNumber.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InternationalDateToNumber : IInternationalDateToNumber
	{
		readonly IApplicationDB appDB;
		
		public InternationalDateToNumber(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string InternationalDateToNumberFn(
			DateTime? DateValue)
		{
			GenericDateType _DateValue = DateValue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[InternationalDateToNumber](@DateValue)";
				
				appDB.AddCommandParameter(cmd, "DateValue", _DateValue, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
