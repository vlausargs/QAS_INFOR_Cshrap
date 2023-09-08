//PROJECT NAME: Material
//CLASS NAME: MrpOrderActionStartDate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpOrderActionStartDate : IMrpOrderActionStartDate
	{
		readonly IApplicationDB appDB;
		
		public MrpOrderActionStartDate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public DateTime? MrpOrderActionStartDateFn(
			DateTime? XStartDate,
			int? LeadTime)
		{
			DateType _XStartDate = XStartDate;
			IntType _LeadTime = LeadTime;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MrpOrderActionStartDate](@XStartDate, @LeadTime)";
				
				appDB.AddCommandParameter(cmd, "XStartDate", _XStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<DateTime?>(cmd);
				
				return Output;
			}
		}
	}
}
