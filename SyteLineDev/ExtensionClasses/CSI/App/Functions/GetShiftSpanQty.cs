//PROJECT NAME: Data
//CLASS NAME: GetShiftSpanQty.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetShiftSpanQty : IGetShiftSpanQty
	{
		readonly IApplicationDB appDB;
		
		public GetShiftSpanQty(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GetShiftSpanQtySp(
			DateTime? TransDate,
			string Shift)
		{
			DateTimeType _TransDate = TransDate;
			ShiftType _Shift = Shift;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetShiftSpanQtySp](@TransDate, @Shift)";
				
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Shift", _Shift, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
