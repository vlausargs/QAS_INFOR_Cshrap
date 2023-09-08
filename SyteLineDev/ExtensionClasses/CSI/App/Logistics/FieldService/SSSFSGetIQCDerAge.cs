//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetIQCDerAge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetIQCDerAge : ISSSFSGetIQCDerAge
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetIQCDerAge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSGetIQCDerAgeFn(
			DateTime? AsOfDate,
			DateTime? IncDate)
		{
			DateTimeType _AsOfDate = AsOfDate;
			DateTimeType _IncDate = IncDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetIQCDerAge](@AsOfDate, @IncDate)";
				
				appDB.AddCommandParameter(cmd, "AsOfDate", _AsOfDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncDate", _IncDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
