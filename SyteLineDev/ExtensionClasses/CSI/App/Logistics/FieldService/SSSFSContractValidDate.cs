//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContractValidDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContractValidDate : ISSSFSContractValidDate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContractValidDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSContractValidDateFn(
			DateTime? BegDate,
			DateTime? EndDate,
			DateTime? TestDate)
		{
			DateType _BegDate = BegDate;
			DateType _EndDate = EndDate;
			DateType _TestDate = TestDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSContractValidDate](@BegDate, @EndDate, @TestDate)";
				
				appDB.AddCommandParameter(cmd, "BegDate", _BegDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TestDate", _TestDate, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
