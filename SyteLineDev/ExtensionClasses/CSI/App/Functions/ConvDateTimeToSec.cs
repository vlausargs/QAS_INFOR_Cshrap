//PROJECT NAME: Data
//CLASS NAME: ConvDateTimeToSec.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConvDateTimeToSec : IConvDateTimeToSec
	{
		readonly IApplicationDB appDB;
		
		public ConvDateTimeToSec(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ConvDateTimeToSecFn(
			DateTime? Date)
		{
			DateTimeType _Date = Date;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConvDateTimeToSec](@Date)";
				
				appDB.AddCommandParameter(cmd, "Date", _Date, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
