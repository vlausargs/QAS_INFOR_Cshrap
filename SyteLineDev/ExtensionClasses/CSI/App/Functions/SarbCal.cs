//PROJECT NAME: Data
//CLASS NAME: SarbCal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SarbCal : ISarbCal
	{
		readonly IApplicationDB appDB;
		
		public SarbCal(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SarbCalSp(
			DateTime? PFutureDate,
			DateTime? PNewDate)
		{
			DateType _PFutureDate = PFutureDate;
			DateType _PNewDate = PNewDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SarbCalSp](@PFutureDate, @PNewDate)";
				
				appDB.AddCommandParameter(cmd, "PFutureDate", _PFutureDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDate", _PNewDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
