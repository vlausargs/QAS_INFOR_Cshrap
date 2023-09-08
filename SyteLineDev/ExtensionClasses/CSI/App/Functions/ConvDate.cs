//PROJECT NAME: Data
//CLASS NAME: ConvDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvDate : IConvDate
	{
		readonly IApplicationDB appDB;
		
		public ConvDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string ConvDateFn(
			DateTime? pInputDate,
			string pFormat)
		{
			DateType _pInputDate = pInputDate;
			StringType _pFormat = pFormat;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvDate](@pInputDate, @pFormat)";
				
				appDB.AddCommandParameter(cmd, "pInputDate", _pInputDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFormat", _pFormat, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
